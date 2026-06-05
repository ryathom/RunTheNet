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

        public void Execute()
        {
            EncounterManager.Instance.Runner.SetClicks(Clicks);
        }

        public IEffect Copy()
        {
            return new SetClicks(Clicks);
        }

    }
}