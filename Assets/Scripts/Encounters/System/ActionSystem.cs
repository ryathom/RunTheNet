using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters
{
    public class ActionSystem
    {
        public Queue<IAction> ActionQueue {get; private set;}
        public Stack<IStackAction> ActionStack {get; private set;}
        public IAction CurrentAction {get; private set;}

        public bool Busy {get; private set;}

        public int ProgramCounter {get; private set;}

        public ActionSystem()
        {
            ActionQueue = new();
            ActionStack = new();
            Busy = false;
        }

        public void AddAction(IAction action)
        {
            if (action is IStackAction stackAction)
            {
                ActionStack.Push(stackAction);
            } else
            {
                ActionQueue.Enqueue(action);
            }
        }

        public IEnumerator ExecuteNextAction()
        {
            if (ActionQueue.Count > 0)
            {
                CurrentAction = ActionQueue.Dequeue();
            } else if (ActionStack.Count > 0)
            {
                CurrentAction = ActionStack.Pop();
            } else
            {
                CurrentAction = null;
                yield break;
            }

            Busy = true;
            yield return CurrentAction.Execute();

            CheckTriggeredAbilities(CurrentAction);

            ManageCorpTurn();

            Busy = false;
        }

        public IEnumerator ExecuteImmediate(IAction action)
        {
            yield return action.Execute();

            CheckTriggeredAbilities(action);
        }

        public void CheckTriggeredAbilities(IAction action)
        {
            foreach (Card card in EncounterManager.Instance.Runner.Rig.Cards)
            {
                foreach (IAbility ability in card.Abilities)
                {
                    if (ability is TriggeredAbility triggeredAbility)
                    {
                        if (triggeredAbility.Trigger.HasTriggered(action, card))
                        {
                            AddAction(new ResolveAbility(triggeredAbility, card));
                        }
                    }
                }
            }

            foreach (Card card in EncounterManager.Instance.Server.Cards)
            {
                foreach (IAbility ability in card.Abilities)
                {
                    if (ability is TriggeredAbility triggeredAbility)
                    {
                        if (triggeredAbility.Trigger.HasTriggered(action, card))
                        {
                            AddAction(new ResolveAbility(triggeredAbility, card));
                        }
                    }
                }
            }
        }

        public void SetProgramCounter(int pc)
        {
            ProgramCounter = pc;
        }

        public void ModifyProgramCounter(int mod)
        {
            ProgramCounter += mod;
        }

        public void ManageCorpTurn()
        {
            if (EncounterManager.Instance.EncounterInfo.CurrentPhase is not CorpPhase) return;
            if (ActionQueue.Count != 0) return;
            if (ActionStack.Count != 0) return;

            if (ProgramCounter >= 0)
            {
                AddAction(new ExecuteSubroutines(ProgramCounter));
            } else
            {
                AddAction(new EndCorpTurn());
            }
        }
    }
}