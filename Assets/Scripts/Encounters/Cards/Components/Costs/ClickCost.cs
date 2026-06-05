using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class ClickCost : ICost
    {
        public int Clicks;

        public ClickCost() {}

        public ClickCost(int clicks)
        {
            Clicks = clicks;
        }

        public IEnumerator Pay()
        {
            EncounterManager.Instance.Runner.SpendClicks(Clicks);
            return null;
        }

        public bool CanPay()
        {
            return EncounterManager.Instance.Runner.Clicks >= Clicks;
        }

        public ICost Copy()
        {
            return new ClickCost(Clicks);
        }
    }
}