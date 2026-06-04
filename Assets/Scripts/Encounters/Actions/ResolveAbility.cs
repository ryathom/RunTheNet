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

    public class ExecuteSubroutines : IAction
    {
        public Card Card {get; private set;}

        public ExecuteSubroutines(Card card)
        {
            Card = card;
        }

        public IEnumerator Execute()
        {
            foreach (IAbility ability in Card.Abilities)
            {
                if (ability is Subroutine subroutine)
                {
                    yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ResolveAbility(subroutine, Card));
                }
            }
        }
    }
}