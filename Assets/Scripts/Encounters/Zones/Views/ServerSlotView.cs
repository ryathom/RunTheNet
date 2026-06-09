using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Test change for new branch

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerSlotView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public ServerSlot ServerSlot;
        public Action<ServerSlot> OnClickSlot;
        public Action<ServerSlot> OnEnterSlot;
        public Action<ServerSlot> OnExitSlot;

        // public Image outline;

        // private void Start()
        // {
        //     ShowOutline(false);
        // }

        // public void ShowOutline(bool enabled)
        // {
        //     outline.enabled = enabled;
        // }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickSlot?.Invoke(ServerSlot);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnterSlot?.Invoke(ServerSlot);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExitSlot?.Invoke(ServerSlot);
        }

        public bool CheckBounds(Vector2 position)
        {
            RectTransform rect = GetComponent<RectTransform>();

            return RectTransformUtility.RectangleContainsScreenPoint(rect, position);
        }
    }
}