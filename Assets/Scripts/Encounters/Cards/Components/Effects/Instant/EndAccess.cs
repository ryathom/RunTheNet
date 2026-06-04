using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class EndAccess : IEffect
    {
        public void Execute()
        {
            Debug.Log("Should end the access");
        }

        public IEffect Copy()
        {
            return new EndAccess();
        }
    }
}