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

        private float pointerDelay = 1f;

        public ExecuteSubroutines(int pc)
        {
            Card = EncounterManager.Instance.Server.Slots[pc].Card;
            
            PC = pc;
        }

        public IEnumerator Execute()
        {
            EncounterManager.Instance.ServerView.ShowStackPointer(PC);

            if (Card != null && Card.Active)
            {
                foreach (IAbility ability in Card.Abilities)
                {
                    if (ability is Subroutine subroutine)
                    {
                        EncounterManager.Instance.Actions.AddAction(new ResolveAbility(subroutine, Card));
                    }
                }
            }

            yield return new WaitForSeconds(pointerDelay);

            EncounterManager.Instance.Actions.ModifyProgramCounter(-1);
        }
    }
}