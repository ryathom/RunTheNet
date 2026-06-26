using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Run
{
    public class RunUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private RepoBrowser repoBrowser;

        [SerializeField] private List<Button> EncounterButtons;

        private void Start()
        {
            ShowRepoBrowser(false);
            ShowValidEncounters();
        }

        private void Update()
        {
            creditsText.text = "Credits: " + RunManager.Instance.Credits;
        }

        public void ShowValidEncounters()
        {
            for (int i = 0; i < EncounterButtons.Count; i++)
            {
                if (i == RunManager.Instance.ProgressLevel)
                {
                    EncounterButtons[i].GetComponent<Image>().color = Color.white;
                } else
                {
                    EncounterButtons[i].GetComponent<Image>().color = Color.grey;
                }
            }
        }

        public void ShowRepoBrowser(bool enabled)
        {
            repoBrowser.gameObject.SetActive(enabled);

            if (enabled)
            {
                repoBrowser.ShowRepo();
            }
        }
    }
}