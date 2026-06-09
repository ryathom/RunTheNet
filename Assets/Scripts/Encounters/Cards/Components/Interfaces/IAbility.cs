using System.Collections;
using System.Collections.Generic;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface IAbility
    {
        public IEnumerator Execute(Card source);
        public IAbility Copy();
    }
}