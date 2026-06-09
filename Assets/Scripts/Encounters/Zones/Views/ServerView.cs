using System;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerView : ZoneView
    {
        [SerializeField] private Image stackPointerArrow;

        private Server server;
        public List<ServerSlotView> ServerSlots;

        public Action<ServerSlot> OnClickServerSlot;
        public Action<ServerSlot> OnEnterServerSlot;
        public Action<ServerSlot> OnExitServerSlot;
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
                ServerSlots[i].OnEnterSlot += EnterServerSlot;
                ServerSlots[i].OnExitSlot += ExitServerSlot;
            }
        }

        public void HideStackPointer()
        {
            stackPointerArrow.enabled = false;
        }

        public void ShowStackPointer(int pos)
        {
            float x = ServerSlots[pos].transform.localPosition.x;
            float y = stackPointerArrow.transform.localPosition.y;

            Quaternion q = stackPointerArrow.transform.localRotation;

            stackPointerArrow.transform.SetLocalPositionAndRotation(new(x, y, 0), q);
            stackPointerArrow.enabled = true;
        }

        public ServerSlot GetServerSlotAtPosition(Vector2 position)
        {
            foreach (ServerSlotView slotView in ServerSlots)
            {
                if (slotView.CheckBounds(position) == true)
                {
                    return slotView.ServerSlot;
                }
            }

            return null;
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

        public void EnterServerSlot(ServerSlot slot)
        {
            OnEnterServerSlot?.Invoke(slot);
        }

        public void ExitServerSlot(ServerSlot slot)
        {
            OnExitServerSlot?.Invoke(slot);
        }
    }
}