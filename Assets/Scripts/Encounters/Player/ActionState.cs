namespace ryathom.RunTheNet.Encounters.Player
{
    public class ActionState : PlayerControllerState
    {
        public ActionState(PlayerController _pc) : base(_pc)
        {
        }

        public override void Enter()
        {
            Phase.OnPhaseEnter += ExitActionState;
        }

        public override void Exit()
        {
            Phase.OnPhaseEnter -= ExitActionState;
        }

        private void ExitActionState(Phase phase)
        {
            if (phase is not RunnerMainPhase)
            {
                controller.ChangeState(controller.NoInputState);
            }
        }
    }
}