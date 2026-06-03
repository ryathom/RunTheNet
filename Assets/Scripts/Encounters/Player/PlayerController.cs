using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Runner Runner {get; private set;}
        public ActionSystem ActionSystem {get; private set;}

        public PlayerControllerState CurrentState {get; private set;}

        public NoInputState NoInputState {get; private set;}
        public PausedState PausedState {get; private set;}
        public ActionState ActionState {get; private set; }
        public CardSelectState CardSelectState {get; private set;}


        // Encounter setup
        //---------------------------------------------------------------------------------------------------------
        public void Setup(ActionSystem system, Runner runner)
        {
            ActionSystem = system;
            Runner = runner;

            SetupStateMachine();
        }

        private void SetupStateMachine()
        {
            NoInputState = new(this);
            ActionState = new(this);
            CardSelectState = new(this);
            PausedState = new(this);

            CurrentState = NoInputState;
            CurrentState.Enter();
        }

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Update()
        {
            CurrentState?.Update();
        }

        private void OnDestroy()
        {
            CurrentState?.Exit();
        }

        // Other methods
        //---------------------------------------------------------------------------------------------------------
        public void ChangeState(PlayerControllerState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}