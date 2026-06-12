using UnityEngine;
using ryathom.RunTheNet.Encounters.Player;
using TMPro;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class RunnerPlayArea : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ClicksText;
        [SerializeField] private TextMeshProUGUI EnergyText;

        public HandView HandView;
        public RigView RigView;
        public TrashView TrashView;

        private Runner runner;

        public void SetupPlayArea(Runner runner)
        {
            this.runner = runner;

            HandView.SetZone(runner.Hand);
            RigView.SetZone(runner.Rig);
            TrashView.SetZone(runner.Trash);
        }

        public void Update()
        {
            if (runner == null) return;

            ClicksText.text = "Clicks: " + runner.Clicks.ToString();
            EnergyText.text = "Energy: " + runner.Energy.ToString();
        }
    }
}