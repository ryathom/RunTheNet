using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class TrashCard : IAction
    {
        public Card Card {get; private set;}

        public TrashCard() {}

        public TrashCard(Card card)
        {
            Card = card;
        }

        public IEnumerator Execute()
        {
            if (Card == null) yield break;

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Card, EncounterManager.Instance.Runner.Trash));
        }
    }
}