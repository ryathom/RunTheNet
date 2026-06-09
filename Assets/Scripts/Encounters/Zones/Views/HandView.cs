using System;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ryathom.RunTheNet.Encounters.Zones
{

    public class HandView : ZoneView, IPointerEnterHandler, IPointerExitHandler
    {
        private readonly float cardSpacing = 244;
        private int yScale = 60;
        private int zRotationFactor = -5;
        private Vector3 handScale = new(1f, 1f, 1f);

        private Vector3 mouseOverOffset = new(0f, 60f);

        public Action<Card> OnClickCardInHand;
        public Action<Card, PointerEventData> OnEndDragFromHand;

        // Methods
        //---------------------------------------------------------------------------------------------------------
        public override void UpdateVisuals()
        {
            for (int i = 0; i < containers.Count; i++)
            {
                float relativePosition = i - ((containers.Count - 1f) / 2f);
                
                float x = relativePosition * cardSpacing;

                float y = -1 - (relativePosition * relativePosition / (containers.Count * 2));
                y *= yScale;


                Vector2 targetPosition = new(x, y);

                containers[i].transform.SetAsLastSibling();
                containers[i].SetTargetPosition(this.transform.position + (Vector3)targetPosition);
                containers[i].SetScale(handScale);

                float zRotation = relativePosition * zRotationFactor;
                containers[i].transform.eulerAngles = new Vector3(0, 0, zRotation);

                containers[i].ShowVisual(true);
            }
        }

        // Event responses
        //---------------------------------------------------------------------------------------------------------
        protected override void ClickCard(Card card)
        {
            OnClickCardInHand?.Invoke(card);
        }

        protected override void BeginDragContainer(CardContainer container)
        {
            container.SetDragging(true);
        }

        protected override void EndDragContainer(CardContainer container, PointerEventData eventData)
        {
            container.SetDragging(false);
            OnEndDragFromHand?.Invoke(container.Card, eventData);
            UpdateVisuals();
        }

        protected override void EnterContainer(CardContainer container)
        {
            if (container.IsDragging) return;

            container.transform.SetAsLastSibling();
            container.SetTargetPosition(container.transform.position + mouseOverOffset);
            container.SetScale(new Vector3(1.25f, 1.25f, 1f));
            container.transform.eulerAngles = Vector3.zero;
        }

        protected override void ExitContainer(CardContainer container)
        {
            if (container.IsDragging) return;
            
            UpdateVisuals();
        }

        


        // Interface methods
        //---------------------------------------------------------------------------------------------------------
        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}