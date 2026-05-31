using UnityEngine;
using UnityEngine.EventSystems;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardContainer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
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