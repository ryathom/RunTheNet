using System;
using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [Serializable]
    public class TriggeredAbility : IAbility
    {
        [SerializeReference, SubclassSelector]
        public ITrigger Trigger;

        [SerializeReference, SubclassSelector]
        public IEffect Effect;

        public IEnumerator Execute()
        {
            yield return Effect.Execute();
        }

        public IAbility Copy()
        {
            TriggeredAbility ability = new()
            {
                Trigger = Trigger.Copy(),
                Effect = Effect.Copy(),
            };
            return ability;
        }
    }
}