using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    public class RunUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditsText;

        private void Update()
        {
            creditsText.text = "Credits: " + RunManager.Instance.Credits;
        }
    }
}