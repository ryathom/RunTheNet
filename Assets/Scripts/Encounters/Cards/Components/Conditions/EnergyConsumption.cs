namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class EnergyConsumption : ICondition
    {
        public int Value;

        public EnergyConsumption() {}

        public EnergyConsumption(int value)
        {
            Value = value;
        }

        public bool Evaluate(Card source)
        {
            if (EncounterManager.Instance.Runner.Energy >= Value)
            {
                EncounterManager.Instance.Runner.SpendEnergy(Value);
                return true;
            }

            return false;
        }

        public ICondition Copy()
        {
            return new EnergyConsumption(Value);
        }
    }
}