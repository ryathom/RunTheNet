using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class TriggeredAbility : IAbility
    {
        [SerializeReference, SubclassSelector]
        public ITrigger Trigger;

        [SerializeReference, SubclassSelector]
        public IEffect Effect;

        public void Execute()
        {
            Effect.Execute();
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