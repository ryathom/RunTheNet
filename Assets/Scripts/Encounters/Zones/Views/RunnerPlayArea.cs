using UnityEngine;
using ryathom.RunTheNet.Encounters.Player;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class RunnerPlayArea : MonoBehaviour
    {
        public HandView HandView;
        public RigView RigView;

        public void SetupPlayArea(Runner runner)
        {
            HandView.SetZone(runner.Hand);
            RigView.SetZone(runner.Rig);
        }
    }
}