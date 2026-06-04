using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class EndAccess : IEffect
    {
        public void Execute()
        {
            EncounterManager.Instance.Actions.SetProgramCounter(-1);
        }

        public IEffect Copy()
        {
            return new EndAccess();
        }
    }
}