using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class BreakIce : IEffect
    {
        public void Execute()
        {
            int pc = EncounterManager.Instance.Actions.ProgramCounter;
            Card nextCard = EncounterManager.Instance.Server.GetCardAtSlot(pc);
            // REVISIT 06/05 - this should be (PC - 1) but action system isn't working correctly atm

            if (nextCard is Ice)
            {
                nextCard.Deactivate();
            }
        }

        public IEffect Copy()
        {
            return new BreakIce();
        }

    }
}