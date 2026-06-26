using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ExecuteSubroutines : IStackAction
    {
        public Card Card {get; private set;}
        public int PC {get; private set;}

        private float pointerDelay = 0.75f;
        private Vector3 hlScale = new(1.1f, 1.1f, 1f);

        public ExecuteSubroutines(int pc)
        {
            Card = EncounterManager.Instance.Server.Slots[pc].Card;
            
            PC = pc;
        }

        public IEnumerator Execute()
        {
            EncounterManager.Instance.ServerView.ShowStackPointer(PC);
            Card.Container.SetScale(hlScale);

            if (Card != null && Card.Active)
            {
                foreach (IAbility ability in Card.Abilities)
                {
                    if (ability is Subroutine subroutine)
                    {
                        if (subroutine.Condition.Evaluate(Card))
                        {
                            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ResolveAbility(subroutine, Card));
                        }
                    }
                }
            }

            EncounterInfo info = EncounterManager.Instance.EncounterInfo;

            if (info.Trace >= info.MaxTrace)
            {
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new EndEncounter(success: false));
            }

            yield return new WaitForSeconds(pointerDelay);
            Card.Container.SetScale(Vector3.one);

            EncounterManager.Instance.Actions.ModifyProgramCounter(-1);
        }
    }
}