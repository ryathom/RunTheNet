using System;
using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [Serializable]
    public class Subroutine : IAbility
    {
        [SerializeReference, SubclassSelector]
        public ICondition Condition = new NoCondition();

        [SerializeReference, SubclassSelector]
        public IEffect Effect;

        public IEnumerator Execute(Card source)
        {
            yield return Effect.Execute(source);
        }

        public IAbility Copy()
        {
            Subroutine ability = new()
            {
                Condition = Condition.Copy(),
                Effect = Effect.Copy(),
            };
            return ability;
        }

        public IEffect GetEffect()
        {
            return Effect;
        }
    }
}