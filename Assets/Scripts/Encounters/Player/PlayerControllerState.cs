using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Player
{
    public abstract class PlayerControllerState
    {
        protected PlayerController controller;

        public PlayerControllerState(PlayerController _pc)
        {
            controller = _pc;
        }

        public virtual void Enter() {}
        public virtual void Exit() {}
        public virtual void Update() {}
    }

    public class NoInputState : PlayerControllerState
    {
        public NoInputState(PlayerController _pc) : base(_pc)
        {
        }
    }

    public class PausedState : PlayerControllerState
    {
        public PausedState(PlayerController _pc) : base(_pc)
        {
        }
    }

    public class ActionState : PlayerControllerState
    {
        public ActionState(PlayerController _pc) : base(_pc)
        {
        }
    }

    public class CardSelectState : PlayerControllerState
    {
        public CardSelectState(PlayerController _pc) : base(_pc)
        {
        }
    }
}