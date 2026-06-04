using System;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [Serializable]
    public class ModifyProgramCounter : IEffect
    {
        public int Modifier;

        public ModifyProgramCounter() {}

        public ModifyProgramCounter(int mod)
        {
            Modifier = mod;
        }

        public void Execute()
        {
            EncounterManager.Instance.Actions.ModifyProgramCounter(Modifier);
        }

        public IEffect Copy()
        {
            return new ModifyProgramCounter(Modifier);
        }
    }
}