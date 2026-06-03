using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters
{
    public class EncounterUIManager : MonoBehaviour
    {
        public static EncounterUIManager Instance {get; private set;}

        private EncounterInfo info;

        [SerializeField] private TextMeshProUGUI traceText;

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
            info = EncounterManager.Instance.EncounterInfo;
        }

        public void Update()
        {
            UpdateTraceText(info.Trace, info.MaxTrace);
        }

        public void UpdateTraceText(int traceValue, int maxTrace)
        {
            traceText.text = "Trace: " + traceValue + "/" + maxTrace;
        }
    }
}