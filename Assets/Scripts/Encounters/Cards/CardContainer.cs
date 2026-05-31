using UnityEngine;
using UnityEngine.EventSystems;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardContainer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CardVisual cardVisual;
        [SerializeField] private CardSO testCardSO;

        public Card Card {get; private set;}

        public void Start()
        {
            SetCard(new(testCardSO));
        }

        public void SetCard(Card card)
        {
            Card = card;
            Card.SetContainer(this);

            cardVisual.SetCard(card);
        }


        // Interface methods
        // -------------------------------------------------------
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("pointer down");
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
    }
}