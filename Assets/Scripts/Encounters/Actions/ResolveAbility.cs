using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ResolveAbility : IAction
    {
        public IAbility Ability {get; private set;}
        public Card Source {get; private set;}

        public ResolveAbility(IAbility ability, Card source)
        {
            Ability = ability;
            Source = source;
        }

        public IEnumerator Execute()
        {
            Ability.Execute();

            return null;
        }
    }
}