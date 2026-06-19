using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ryathom.RunTheNet
{
    public class InputManager : MonoBehaviour
    {
        private InputAction pointAction;
        private InputAction clickAction;
        private InputAction scrollAction;

        // Events
        public Action OnClickAction;

        public static InputManager Instance;


        // Main Unity methods
        //---------------------------------------------------------------------------------------------------------
        private void Awake() 
        {
            if (Instance == null) {
                Instance = this;
            } else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            pointAction = InputSystem.actions.FindAction("Point");
            clickAction = InputSystem.actions.FindAction("Click");
            scrollAction = InputSystem.actions.FindAction("ScrollWheel");
        }

        private void Update()
        {
            if (clickAction.WasPressedThisFrame())
            {
                OnClickAction?.Invoke();
            }
         }

        // Expose inputs
        //---------------------------------------------------------------------------------------------------------
        public Vector2 GetPointInput()
        {
            return pointAction.ReadValue<Vector2>();
        }

        public Vector2 GetScrollInput()
        {
            return scrollAction.ReadValue<Vector2>();
        }
    }
}