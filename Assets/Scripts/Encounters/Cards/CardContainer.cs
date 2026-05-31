using UnityEngine;
using UnityEngine.EventSystems;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardContainer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
                                , IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CardVisual cardVisual;
        [SerializeField] private float moveSpeed = 15;

        public Card Card {get; private set;}

        public bool IsDragging {get; private set;}
        public Vector2 TargetPosition {get; private set;}

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
                transform.position = Vector3.Lerp(transform.position, TargetPosition, moveSpeed * Time.deltaTime);
            }
        }


        // Interface methods
        // -------------------------------------------------------
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            IsDragging = false;
        }
    }
}