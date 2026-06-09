using System.Collections;
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

        public IEnumerator Execute(Card source)
        {
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new IncreaseTrace(Value));
        }

        public IEffect Copy()
        {
            return new IncreaseTraceEffect(Value);
        }
    }
}