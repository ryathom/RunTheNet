using System;
using UnityEngine;
using UnityEngine.EventSystems;
using PrimeTween;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardContainer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
                                , IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CardVisual cardVisual;
        [SerializeField] private float dragSpeed = 15;

        public Card Card {get; private set;}

        public Zone Zone;

        public bool IsDragging {get; private set;}
        public Vector2 TargetPosition {get; private set;}
        public Vector2 ReturnPosition {get; private set;}

        public Action<Card> OnClickCard;
        public Action<CardContainer> OnBeginDragContainer;
        public Action<CardContainer, PointerEventData> OnEndDragContainer;
        public Action<CardContainer> OnEnterContainer;
        public Action<CardContainer> OnExitContainer;

        public void SetCard(Card card)
        {
            Card = card;
            Card.SetContainer(this);

            cardVisual.SetCard(card);
        }

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Update()
        {
            if (IsDragging)
            {
                TargetPosition = InputManager.Instance.GetPointInput();
                transform.position = Vector3.Lerp(transform.position, TargetPosition, dragSpeed * Time.deltaTime);
            }

            // if (Card != null && Card is Hardware && Card.Zone != null)
            // {
            //     Debug.Log("hello I am hardware and my zone is " + Card.Zone.GetType().Name);
            // }
        }

        // UX methods
        // -------------------------------------------------------
        public void ShowVisual(bool enabled)
        {
            if (enabled) cardVisual.UpdateVisuals();
            
            cardVisual.gameObject.SetActive(enabled);

        }

        public void SetTargetPosition(Vector2 pos)
        {
            TargetPosition = pos;
            ReturnPosition = pos;

            if ((Vector2)transform.position != TargetPosition)
            {
                Tween.Position(transform, TargetPosition, 0.25f);
            }
        }

        public void SetScale(Vector3 scale)
        {
            if (transform.localScale != scale)
            {
                Tween.Scale(transform, scale, 0.1f);
            }
        }

        public void SetDragging(bool dragging)
        {
            IsDragging = dragging;
        }


        // Interface methods
        // -------------------------------------------------------
        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnterContainer?.Invoke(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExitContainer?.Invoke(this);

            SetScale(new Vector3(1f, 1f, 1f));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsDragging == false && eventData.button == PointerEventData.InputButton.Left)
            {
                OnClickCard?.Invoke(Card);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDragContainer?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragContainer?.Invoke(this, eventData);
        }
    }
}