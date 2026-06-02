using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    public class RunManager : MonoBehaviour
    {
        public void StartEncounter()
        {
            GameManager.Instance.LoadScene("EncounterScene");
        }
    }
}