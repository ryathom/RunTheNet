using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Cards;

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
            
            controller.PlayArea.HandView.OnClickCardInHand += PlayCard;
        }

        public override void Exit()
        {
            Phase.OnPhaseEnter -= ExitActionState;

            controller.PlayArea.HandView.OnClickCardInHand -= PlayCard;
        }

        private void ExitActionState(Phase phase)
        {
            if (phase is not RunnerMainPhase)
            {
                controller.ChangeState(controller.NoInputState);
            }
        }

        private void PlayCard(Card card)
        {
            EncounterManager.Instance.Actions.AddAction(new InstallProgram(card));
        }
    }
}