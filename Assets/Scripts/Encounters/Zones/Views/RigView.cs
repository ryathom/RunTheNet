using System;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ryathom.RunTheNet.Encounters.Zones
{

    public class RigView : ZoneView, IPointerEnterHandler, IPointerExitHandler
    {
        private readonly float cardSpacing = 280;
        private Vector3 rigScale = new(1f, 1f, 1f);

        public Action<Card> OnClickCardInRig;

        // Methods
        //---------------------------------------------------------------------------------------------------------
        public override void UpdateVisuals()
        {
            for (int i = 0; i < containers.Count; i++)
            {
                float relativePosition = i - ((containers.Count - 1f) / 2f);
                
                float x = relativePosition * cardSpacing;


                Vector2 targetPosition = new(x, 0);

                containers[i].transform.SetAsLastSibling();
                containers[i].SetTargetPosition(this.transform.position + (Vector3)targetPosition);
                containers[i].SetScale(rigScale);
                containers[i].ShowVisual(true);
                containers[i].transform.eulerAngles = Vector3.zero;
            }
        }

        // Event responses
        //---------------------------------------------------------------------------------------------------------
        protected override void ClickCard(Card card)
        {
            OnClickCardInRig?.Invoke(card);
        }

        protected override void BeginDragContainer(CardContainer container)
        {
        }

        protected override void EndDragContainer(CardContainer container, PointerEventData eventData)
        {
        }

        protected override void EnterContainer(CardContainer container)
        {
            container.transform.SetAsLastSibling();
            container.SetScale(new Vector3(1.25f, 1.25f, 1f));
        }

        protected override void ExitContainer(CardContainer container)
        {   
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