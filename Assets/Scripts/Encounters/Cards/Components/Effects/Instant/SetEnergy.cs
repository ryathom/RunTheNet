using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class SetEnergy : IEffect
    {
        public int Value;

        public SetEnergy() {}

        public SetEnergy(int value)
        {
            Value = value;
        }

        public IEnumerator Execute(Card source)
        {
            EncounterManager.Instance.Runner.SetEnergy(Value);
            yield return null;
        }

        public IEffect Copy()
        {
            return new SetEnergy(Value);
        }
    }
}