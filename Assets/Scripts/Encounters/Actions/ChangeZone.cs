using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ChangeZone : IAction
    {
        public Card Card {get; private set;}
        public Zone EndZone {get; private set;}

        public ChangeZone(Card card, Zone endZone)
        {
            Card = card;
            EndZone = endZone;
        }

        public IEnumerator Execute()
        {
            Card.Zone.RemoveCard(Card);
            EndZone.AddCard(Card);

            yield return null;
        }
    }
}