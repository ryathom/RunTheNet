
using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    public class MapManager : MonoBehaviour
    {

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------


        // Game flow
        //---------------------------------------------------------------------------------------------------------
        public void StartEncounter()
        {
            RunManager.Instance.StartEncounter();
        }
    }
}