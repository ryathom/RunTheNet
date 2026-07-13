using System.Collections.Generic;
using ryathom.RunTheNet.Run.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Run
{
    public class RunUIManager : MonoBehaviour
    {
        public static RunUIManager Instance {get; private set;}

        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private RepoBrowser repoBrowser;
        [SerializeField] private EventPopUp eventPopUp;
        [SerializeField] private EventPopUp shopPopUp;

        private void Awake() 
        {
            if (Instance == null) {
                Instance = this;
            } else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ShowRepoBrowser(false);
            ShowEventPopup(false);
            ShowShopPopup(false);
        }

        private void Update()
        {
            creditsText.text = "Credits: " + RunManager.Instance.Credits;
        }

        public void ShowRepoBrowser(bool enabled)
        {
            repoBrowser.gameObject.SetActive(enabled);

            if (enabled)
            {
                repoBrowser.ShowRepo();
            }
        }

        public void ShowEventPopup(bool enabled)
        {
            eventPopUp.gameObject.SetActive(enabled);
        }

        public void ShowShopPopup(bool enabled)
        {
            shopPopUp.gameObject.SetActive(enabled);
        }
    }
}