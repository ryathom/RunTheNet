using UnityEngine;

namespace ryathom.RunTheNet
{
    public class GameManager : MonoBehaviour
    {
        public void Start()
        {
            InputManager.Instance.OnClickAction += Log;
        }

        public void Log()
        {
            Debug.Log(InputManager.Instance.GetPointInput());
        }
    }
}