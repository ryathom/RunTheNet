namespace ryathom.RunTheNet.Encounters.Player
{
    public class NoInputState : PlayerControllerState
    {
        public NoInputState(PlayerController _pc) : base(_pc)
        {
        }

        public override void Enter()
        {
            Phase.OnPhaseEnter += EnterActionState;
        }

        public override void Exit()
        {
            Phase.OnPhaseEnter -= EnterActionState;
        }

        private void EnterActionState(Phase phase)
        {
            if (phase is RunnerMainPhase)
            {
                controller.ChangeState(controller.ActionState);
            }
        }
    }
}