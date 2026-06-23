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

            if (card is Program program)
            {
                EncounterManager.Instance.Actions.AddAction(new InstallProgram(program, currentSlot));
            }

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

    public class TargetState : PlayerControllerState
    {
        public TargetState(PlayerController _pc) : base(_pc)
        {
        }

        public TargetState(PlayerController _pc, ITargetingEffect effect, Card source) : base(_pc)
        {
            this.effect = effect;
            this.source = source;
        }

        public ITargetingEffect effect;
        private Card source;

        public override void Enter()
        {
            base.Enter();

            controller.PlayArea.HandView.OnClickCardInHand += SelectTarget;
            controller.ServerView.OnClickCardInServer += SelectTarget;
        }

        public override void Exit()
        {
            base.Exit();

            controller.PlayArea.HandView.OnClickCardInHand -= SelectTarget;
            controller.ServerView.OnClickCardInServer -= SelectTarget;
        }

        public void SelectTarget(Card card)
        {
            if (effect.GetValidTargets(source).Contains(card))
            {
                effect.SetTarget(card);

                controller.ChangeState(controller.ActionState);
            }
        }
    }
}