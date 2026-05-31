using System;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public abstract class Zone
    {
        public List<Card> Cards {get; protected set;}

        public Action OnContentsChange;

        public Zone()
        {
            Cards = new();
        }

        public virtual void AddCard(Card card)
        {
            card.SetZone(this);
            Cards.Add(card);
            OnContentsChange?.Invoke();
        }

        public virtual void RemoveCard(Card card)
        {
            Cards.Remove(card);
            OnContentsChange?.Invoke();
        }
    }
}