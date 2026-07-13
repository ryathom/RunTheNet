using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Run.Events
{
    public class EventPopUp : MonoBehaviour
    {
        public void ClosePopUp()
        {
            RunManager.Instance.EndEvent();
        }
    }
}