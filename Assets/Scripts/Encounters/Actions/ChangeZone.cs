using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ChangeZone : IAction
    {
        public Card Card {get; private set;}
        public Zone EndZone {get; private set;}
        public ServerSlot Slot {get; private set;}

        public ChangeZone(Card card, Zone endZone, ServerSlot slot = null)
        {
            Card = card;
            EndZone = endZone;
            Slot = slot;
        }

        public IEnumerator Execute()
        {
            Card.Zone.RemoveCard(Card);

            if (EndZone is Server server && Slot != null)
            {
                server.AddCard(Card, Slot.Index);
            } else
            {
                EndZone.AddCard(Card);
            }


            yield return null;
        }
    }
}