using System.Collections.Generic;
using UnityEngine;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine.EventSystems;


namespace ryathom.RunTheNet.Encounters.Zones
{
    public abstract class ZoneView : MonoBehaviour
    {
        protected Zone zone;
        protected List<CardContainer> containers = new();

        protected RectTransform rectTransform;

        // Unity messages
        //---------------------------------------------------------------------------------------------------------
        public virtual void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public virtual void OnDestroy()
        {
            if (zone != null)
            {
                DeregisterContainers();
                zone.OnContentsChange -= RegisterContainers;
                zone.OnContentsChange -= UpdateVisuals;
            }
        }

        // Methods
        //---------------------------------------------------------------------------------------------------------
        public virtual void SetZone(Zone zone)
        {
            this.zone = zone;
            zone.OnContentsChange += RegisterContainers;
            zone.OnContentsChange += UpdateVisuals;
        }

        public virtual void RegisterContainers()
        {
            DeregisterContainers();

            foreach(Card card in zone.Cards)
            {
                containers.Add(card.Container);
                card.Container.OnClickCard += ClickCard;
                card.Container.OnBeginDragContainer += BeginDragContainer;
                card.Container.OnEndDragContainer += EndDragContainer;
                card.Container.OnEnterContainer += EnterContainer;
                card.Container.OnExitContainer += ExitContainer;
            }
        }

        public virtual void DeregisterContainers()
        {
            foreach (CardContainer container in containers)
            {
                container.OnClickCard -= ClickCard;
                container.OnBeginDragContainer -= BeginDragContainer;
                container.OnEndDragContainer -= EndDragContainer;
                container.OnEnterContainer -= EnterContainer;
                container.OnExitContainer -= ExitContainer;
            }
            containers.Clear();
        }

        public abstract void UpdateVisuals();

        protected virtual void ClickCard(Card card) {}
        protected virtual void BeginDragContainer(CardContainer container) {}
        protected virtual void EndDragContainer(CardContainer container, PointerEventData eventData) {}
        protected virtual void EnterContainer(CardContainer container) {}
        protected virtual void ExitContainer(CardContainer container) {}
    }
}