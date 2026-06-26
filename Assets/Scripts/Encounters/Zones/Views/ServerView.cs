using System;
using System.Collections.Generic;
using PrimeTween;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerView : ZoneView
    {
        [SerializeField] private Image stackPointerArrow;

        private Server server;
        public Transform ServerSlotContainer;
        public List<ServerSlotView> ServerSlots;

        private Reserves reserves;
        public ServerSlotView ReserveSlot;

        public Action<ServerSlot> OnClickServerSlot;
        public Action<ServerSlot> OnEnterServerSlot;
        public Action<ServerSlot> OnExitServerSlot;
        public Action<Card> OnClickCardInServer;

        [SerializeField] private float scrollSpeed = 1f;

        public void Update()
        {
            HandleScroll();
        }

        public override void UpdateVisuals()
        {
            UpdateVisuals(instant: false);
        }

        public void UpdateVisuals(bool instant = false)
        {
            foreach (ServerSlot slot in server.Slots)
            {
                if (slot.IsEmpty) continue;

                int index = server.Slots.IndexOf(slot);

                slot.Card.Container.transform.eulerAngles = new Vector3(0, 0, 0);

                if (instant)
                {
                    slot.Card.Container.transform.SetPositionAndRotation(ServerSlots[index].transform.position, Quaternion.identity);
                } else
                {
                    slot.Card.Container.SetTargetPosition(ServerSlots[index].transform.position);
                }
            }

            foreach (Card card in reserves.Cards)
            {
                card.Container.transform.eulerAngles = new Vector3(0, 0, 0);

                if (instant)
                {
                    card.Container.transform.SetPositionAndRotation(ReserveSlot.transform.position, Quaternion.identity);
                } else
                {
                    card.Container.SetTargetPosition(ReserveSlot.transform.position);
                }

                card.Container.ShowVisual(card == reserves.Cards[0]);
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

        public void SetReserves(Reserves reserves)
        {
            this.reserves = reserves;
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

            if (stackPointerArrow.enabled != true)
            {
                stackPointerArrow.transform.SetLocalPositionAndRotation(new(x, y, 0), q);
            }

            stackPointerArrow.enabled = true;
            Tween.LocalPosition(stackPointerArrow.transform, new Vector3(x, y, 0), duration: 0.2f, ease: Ease.InOutBounce);
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

        public void HandleScroll()
        {
            Vector2 scrollInput = InputManager.Instance.GetScrollInput();
            
            if (scrollInput != Vector2.zero)
            {
                Vector3 translation = new(scrollInput.y * scrollSpeed, 0, 0);

                ServerSlotContainer.Translate(translation);
                UpdateVisuals(instant: true);
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

        public void EnterServerSlot(ServerSlot slot)
        {
            OnEnterServerSlot?.Invoke(slot);
        }

        public void ExitServerSlot(ServerSlot slot)
        {
            OnExitServerSlot?.Invoke(slot);
        }

        protected override void EnterContainer(CardContainer container)
        {
            if (container.IsDragging) return;

            container.transform.SetAsLastSibling();
            container.SetScale(new Vector3(1.2f, 1.2f, 1f));
            container.transform.eulerAngles = Vector3.zero;
        }
    }
}