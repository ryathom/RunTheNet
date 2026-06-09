using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class BreakIce : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            int pc = EncounterManager.Instance.Actions.ProgramCounter;
            Card nextCard = EncounterManager.Instance.Server.GetCardAtSlot(pc - 1);

            if (nextCard is Ice)
            {
                nextCard.Deactivate();
            }

            return null;
        }

        public IEffect Copy()
        {
            return new BreakIce();
        }

    }
}