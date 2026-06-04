using System;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

// Test change for new branch

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerView : ZoneView
    {
        private Server server;
        public List<ServerSlotView> ServerSlots;

        public Action<ServerSlot> OnClickServerSlot;
        public Action<Card> OnClickCardInServer;

        public override void UpdateVisuals()
        {
            foreach (ServerSlot slot in server.Slots)
            {
                if (slot.IsEmpty) continue;

                int index = server.Slots.IndexOf(slot);

                slot.Card.Container.transform.eulerAngles = new Vector3(0, 0, 0);
                slot.Card.Container.SetTargetPosition(ServerSlots[index].transform.position);
            }
        }

        // Methods
        //---------------------------------------------------------------------------------------------------------
        public override void SetZone(Zone zone)
        {
            base.SetZone(zone);
            this.server = (Server)zone;

            for (int i = 0; i < server.Slots.Count; i++)
            {
                ServerSlots[i].ServerSlot = server.Slots[i];
                ServerSlots[i].OnClickSlot += ClickServerSlot;
            }
        }

        // Event responses
        //---------------------------------------------------------------------------------------------------------
        protected override void ClickCard(Card card)
        {
            OnClickCardInServer?.Invoke(card);
        }

        public void ClickServerSlot(ServerSlot slot)
        {
            OnClickServerSlot?.Invoke(slot);
        }
    }
}