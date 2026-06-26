using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    public class RunUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private RepoBrowser repoBrowser;

        private void Start()
        {
            ShowRepoBrowser(false);
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
    }
}