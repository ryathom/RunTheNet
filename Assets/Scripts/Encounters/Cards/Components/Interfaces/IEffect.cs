using System.Collections;
using System.Collections.Generic;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface IEffect
    {
        public IEnumerator Execute();
        public IEffect Copy();
    }

    public interface ITargetingEffect
    {
        public List<Card> GetValidTargets(Card source);
        public void SetTarget(Card target);
        public bool TargetSelected();
    }
}