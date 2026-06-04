using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Test change for new branch

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerSlotView : MonoBehaviour
    {
        public ServerSlot ServerSlot;
        public Action<ServerSlot> OnClickSlot;

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

        // public void OnPointerEnter(PointerEventData eventData)
        // {
        //     if (outline.enabled)
        //     {
        //         outline.color = Color.yellow;
        //     }
        // }

        // public void OnPointerExit(PointerEventData eventData)
        // {
        //     outline.color = Color.white;
        // }
    }
}