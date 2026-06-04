using System;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [Serializable]
    public class Subroutine : IAbility
    {
        [SerializeReference, SubclassSelector]
        public IEffect Effect;

        public void Execute()
        {
            Effect.Execute();
        }

        public IAbility Copy()
        {
            Subroutine ability = new()
            {
                Effect = Effect.Copy(),
            };
            return ability;
        }
    }
}