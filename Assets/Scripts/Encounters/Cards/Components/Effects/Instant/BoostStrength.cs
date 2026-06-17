using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class BoostStrength : IEffect
    {
        public int Value;

        public BoostStrength() {}

        public BoostStrength(int value)
        {
            Value = value;
        }

        public IEnumerator Execute(Card source)
        {
            foreach (Card card in EncounterManager.Instance.Server.Cards)
            {
                if (card is Program program && program.Strength >= 0)
                {
                    program.Strength += Value;
                    program.Container.ShowVisual(true);
                }
            }

            return null;
        }

        public IEffect Copy()
        {
            return new BoostStrength(Value);
        }
    }
}