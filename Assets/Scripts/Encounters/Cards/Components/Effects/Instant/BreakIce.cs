using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class BreakIce : IEffect
    {
        public void Execute()
        {
            Debug.Log("Should break ICE in next slot");
        }

        public IEffect Copy()
        {
            return new BreakIce();
        }

    }
}