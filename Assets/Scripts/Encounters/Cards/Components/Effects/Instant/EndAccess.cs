using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class EndAccess : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            EncounterManager.Instance.Actions.SetProgramCounter(-1);

            return null;
        }

        public IEffect Copy()
        {
            return new EndAccess();
        }
    }
}