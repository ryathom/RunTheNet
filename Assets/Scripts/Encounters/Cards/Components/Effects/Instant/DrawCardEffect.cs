using System;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class DrawCardEffect : IEffect
    {
        public void Execute()
        {
            EncounterManager.Instance.Actions.AddAction(new DrawCard());
        }

        public IEffect Copy()
        {
            return new DrawCardEffect();
        }
    }
}