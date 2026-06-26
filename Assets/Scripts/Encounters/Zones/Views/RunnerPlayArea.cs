using UnityEngine;
using ryathom.RunTheNet.Encounters.Player;
using TMPro;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class RunnerPlayArea : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ClicksText;
        [SerializeField] private TextMeshProUGUI EnergyText;

        [SerializeField] private TextMeshProUGUI RepoCount;
        [SerializeField] private TextMeshProUGUI TrashCount;

        public HandView HandView;
        public RigView RigView;
        public TrashView TrashView;
        public RepoView RepoView;

        private Runner runner;

        public void SetupPlayArea(Runner runner)
        {
            this.runner = runner;

            HandView.SetZone(runner.Hand);
            RigView.SetZone(runner.Rig);
            TrashView.SetZone(runner.Trash);
            RepoView.SetZone(runner.Repository);
        }

        public void Update()
        {
            if (runner == null) return;

            ClicksText.text = "Clicks: " + runner.Clicks.ToString();
            EnergyText.text = "Energy: " + runner.Energy.ToString();
            RepoCount.text = "Deck: " + runner.Repository.Cards.Count.ToString();
            TrashCount.text = "Trash: " + runner.Trash.Cards.Count.ToString();
        }
    }
}