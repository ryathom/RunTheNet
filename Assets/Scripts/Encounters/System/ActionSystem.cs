using System.Collections;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters
{
    public class ActionSystem
    {
        public Queue<IAction> ActionQueue {get; private set;}
        public IAction CurrentAction {get; private set;}

        public bool Busy {get; private set;}

        public ActionSystem()
        {
            ActionQueue = new();
            Busy = false;
        }

        public void AddAction(IAction action)
        {
            ActionQueue.Enqueue(action);
        }

        public IEnumerator ExecuteNextAction()
        {
            if (ActionQueue.Count > 0)
            {
                Busy = true;
                CurrentAction = ActionQueue.Dequeue();
                yield return CurrentAction.Execute();

                CheckTriggeredAbilities(CurrentAction);

                Busy = false;
            }
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
        }
    }
}