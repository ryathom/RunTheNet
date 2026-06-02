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
            EncounterManager.Instance.Actions.AddAction(new IncreaseTrace(Value));
        }

        public IEffect Copy()
        {
            return new IncreaseTraceEffect(Value);
        }
    }
}