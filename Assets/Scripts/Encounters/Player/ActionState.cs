using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

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
            controller.PlayArea.RigView.OnClickCardInRig += ActivateCard;

            // EncounterManager.Instance.ServerView.OnClickCardInServer += AccessServer;
        }

        public override void Exit()
        {
            Phase.OnPhaseEnter -= ExitActionState;

            controller.PlayArea.HandView.OnClickCardInHand -= PlayCard;
            controller.PlayArea.RigView.OnClickCardInRig -= ActivateCard;
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

        private void ActivateCard(Card card)
        {
            if (card.Abilities.Count > 0)
            {
                foreach (IAbility ability in card.Abilities)
                {
                    if (ability is ActivatedAbility activatedAbility)
                    {
                        EncounterManager.Instance.Actions.AddAction(new ResolveAbility(activatedAbility, card));
                    }
                }
            }
        }

        private void AccessServer(Card card)
        {
            if (card is ServerAsset)
            {
                Debug.Log("Attempting to access server");
            } else if (card is Ice)
            {
                Debug.Log("Attempting to break ICE");
            }
        }
    }
}