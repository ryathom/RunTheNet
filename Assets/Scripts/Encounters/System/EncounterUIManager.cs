using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters
{
    public class EncounterUIManager : MonoBehaviour
    {
        public static EncounterUIManager Instance {get; private set;}

        private EncounterInfo info;

        [SerializeField] private TextMeshProUGUI traceText;
        [SerializeField] private RewardsPopUp rewardsPopUp;
        public RewardsPopUp RewardsPopUp {get => rewardsPopUp;}

        private void Awake() 
        {
            if (Instance == null) {
                Instance = this;
            } else
            {
                Destroy(gameObject);
            }
        }

        public void Start()
        {
            ShowRewardsPopUp(false);
        }

        public void Update()
        {
            info ??= EncounterManager.Instance.EncounterInfo;

            if (info == null) return;

            UpdateTraceText(info.Trace, info.MaxTrace);
        }

        public void UpdateTraceText(int traceValue, int maxTrace)
        {
            traceText.text = "Trace: " + traceValue + "/" + maxTrace;
        }

        public void ShowRewardsPopUp(bool enabled)
        {
            rewardsPopUp.transform.SetAsLastSibling();
            rewardsPopUp.gameObject.SetActive(enabled);
        }
    }
}