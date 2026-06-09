using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ryathom.RunTheNet.Encounters.Player
{
    public class ActionState : PlayerControllerState
    {
        public ActionState(PlayerController _pc) : base(_pc)
        {
        }

        private ServerSlot currentSlot;

        public override void Enter()
        {
            Phase.OnPhaseEnter += ExitActionState;
            
            controller.PlayArea.HandView.OnEndDragFromHand += PlayCard;
            controller.PlayArea.RigView.OnClickCardInRig += ActivateCard;
        }

        public override void Exit()
        {
            Phase.OnPhaseEnter -= ExitActionState;

            controller.PlayArea.HandView.OnEndDragFromHand -= PlayCard;
            controller.PlayArea.RigView.OnClickCardInRig -= ActivateCard;
        }

        private void ExitActionState(Phase phase)
        {
            if (phase is not RunnerMainPhase)
            {
                controller.ChangeState(controller.NoInputState);
            }
        }

        private void PlayCard(Card card, PointerEventData eventData)
        {
            currentSlot = controller.ServerView.GetServerSlotAtPosition(eventData.position);

            if (currentSlot == null) return;

            EncounterManager.Instance.Actions.AddAction(new InstallProgram(card, currentSlot));
        }

        private void ActivateCard(Card card)
        {
            if (card.Abilities.Count > 0)
            {
                foreach (IAbility ability in card.Abilities)
                {
                    if (ability is ActivatedAbility activatedAbility && activatedAbility.Cost.CanPay())
                    {
                        EncounterManager.Instance.Actions.AddAction(new ResolveAbility(activatedAbility, card));
                    }
                }
            }
        }
    }
}