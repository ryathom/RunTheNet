using UnityEngine;
using ryathom.RunTheNet.Encounters.Cards;
using System.Collections.Generic;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class Server : Zone
    {
        public List<ServerSlot> Slots {get; private set;}

        public Server() : base()
        {
            Slots = new();
            for (int i = 0; i < 8; i++)
            {
                Slots.Add(new ServerSlot(i));
            }
        }

        // If no slot specified, add to first available slot
        public override void AddCard(Card card) 
        {
            foreach (ServerSlot slot in Slots)
            {
                if (slot.IsEmpty)
                {
                    slot.AddCard(card);
                    base.AddCard(card);
                    return;
                }
            }

            Debug.LogError("Tried to add card to server with no available slots");
        }

        public void AddCard(Card card, int index)
        {
            ServerSlot slot = Slots[index];

            if (slot.IsEmpty)
            {
                slot.AddCard(card);
                base.AddCard(card);
                return;
            }
        }

        public override void RemoveCard(Card card)
        {
            foreach (ServerSlot slot in Slots)
            {
                if (slot.Card == card)
                {
                    slot.RemoveCard();
                    base.RemoveCard(card);
                    return;
                }
            }
        }
    }

    public class ServerSlot
    {
        public Card Card {get; private set;}
        public int Index {get; private set;}

        public bool IsEmpty {get => Card == null;}
        public bool IsOccupied {get => Card != null;}

        public ServerSlot(int index)
        {
            Index = index;
        }

        public void AddCard(Card card)
        {
            if (IsEmpty)
            {
                Card = card;
            } else
            {
                Debug.LogError("Tried to add " + card.Name + " to occupied slot " + Index);
            }
        }

        public void RemoveCard()
        {
            Card = null;
        }
    }
}