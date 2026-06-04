using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class IncreaseTraceEffect : IEffect
    {
        public int Value;

        public IncreaseTraceEffect() {}

        public IncreaseTraceEffect(int value)
        {
            Value = value;
        }

        public void Execute()
        {
            EncounterInfo info = EncounterManager.Instance.EncounterInfo;

            info.Trace += Value;

            // REVISIT - change this to check at end of stack resolution
            if (info.Trace >= info.MaxTrace)
            {
                EncounterManager.Instance.Actions.AddAction(new EndEncounter());
            }
        }

        public IEffect Copy()
        {
            return new IncreaseTraceEffect(Value);
        }
    }
}