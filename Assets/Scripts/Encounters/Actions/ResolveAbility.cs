using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ResolveAbility : IStackAction
    {
        public IAbility Ability {get; private set;}
        public Card Source {get; private set;}

        private readonly float resolveDelay = 0.1f;

        public ResolveAbility(IAbility ability, Card source)
        {
            Ability = ability;
            Source = source;
        }

        public IEnumerator Execute()
        {
            yield return Ability.Execute(Source);

            yield return new WaitForSeconds(resolveDelay);
        }
    }
}