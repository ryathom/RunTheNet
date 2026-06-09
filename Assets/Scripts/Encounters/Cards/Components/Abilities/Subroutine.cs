using System;
using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [Serializable]
    public class Subroutine : IAbility
    {
        [SerializeReference, SubclassSelector]
        public IEffect Effect;

        public IEnumerator Execute()
        {
            yield return Effect.Execute();
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