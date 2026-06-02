using System.Collections.Generic;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface IAbility
    {
        public void Execute();
        public IAbility Copy();
    }
}