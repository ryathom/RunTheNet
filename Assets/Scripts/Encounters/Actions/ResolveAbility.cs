using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ResolveAbility : IStackAction
    {
        public IAbility Ability {get; private set;}
        public Card Source {get; private set;}

        private readonly float resolveDelay = 0.25f;

        public ResolveAbility(IAbility ability, Card source)
        {
            Ability = ability;
            Source = source;
        }

        public IEnumerator Execute()
        {
            if (Ability.GetEffect() is ITargetingEffect effect && effect.TargetSelected() == false
                                    && effect.GetValidTargets(Source).Count > 0)  
            {
                yield return EncounterManager.Instance.PlayerController.GetTargets(effect, Source);
            }

            yield return Ability.Execute(Source);

            yield return new WaitForSeconds(resolveDelay);
        }
    }
}