using System;
using System.Collections;

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

        public IEnumerator Execute()
        {
            EncounterManager.Instance.Actions.ModifyProgramCounter(Modifier);

            return null;
        }

        public IEffect Copy()
        {
            return new ModifyProgramCounter(Modifier);
        }
    }
}