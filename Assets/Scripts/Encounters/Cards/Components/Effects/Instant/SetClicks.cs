using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class SetClicks : IEffect
    {
        public int Clicks;

        public SetClicks() {}

        public SetClicks(int clicks)
        {
            Clicks = clicks;
        }

        public IEnumerator Execute(Card source)
        {
            EncounterManager.Instance.Runner.SetClicks(Clicks);

            return null;
        }

        public IEffect Copy()
        {
            return new SetClicks(Clicks);
        }

    }
}