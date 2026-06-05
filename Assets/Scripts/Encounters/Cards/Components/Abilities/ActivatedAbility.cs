using System;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [Serializable]
    public class ActivatedAbility : IAbility
    {
        [SerializeReference, SubclassSelector]
        public ICost Cost = new ClickCost(1);

        [SerializeReference, SubclassSelector]
        public ICondition Condition;

        [SerializeReference, SubclassSelector]
        public IEffect Effect;

        public string AbilityText;
        public string Text {get => AbilityText;}

        public ActivatedAbility()
        {
        }

        public void Execute()
        {
            Cost.Pay();
            Effect.Execute();
        }

        public IAbility Copy()
        {
            ActivatedAbility ability = new()
            {
                Cost = Cost.Copy(),
                Condition = Condition,
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