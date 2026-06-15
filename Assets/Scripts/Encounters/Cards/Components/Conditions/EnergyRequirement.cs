namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class EnergyRequirement : ICondition
    {
        public int Value;

        public EnergyRequirement() {}

        public EnergyRequirement(int value)
        {
            Value = value;
        }

        public bool Evaluate(Card source)
        {
            if (EncounterManager.Instance.Runner.Energy >= Value)
            {
                return true;
            }

            return false;
        }

        public ICondition Copy()
        {
            return new EnergyRequirement(Value);
        }
    }

    [System.Serializable]
    public class NoCondition : ICondition
    {
        public ICondition Copy()
        {
            return new NoCondition();
        }

        public bool Evaluate(Card source)
        {
            return true;
        }
    }
}