using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class GenerateEnergy : IEffect
    {
        public int Value;

        public GenerateEnergy() {}

        public GenerateEnergy(int value)
        {
            Value = value;
        }

        public IEnumerator Execute(Card source)
        {
            EncounterManager.Instance.Runner.GainEnergy(Value);
            yield return null;
        }

        public IEffect Copy()
        {
            return new GenerateEnergy(Value);
        }
    }
}