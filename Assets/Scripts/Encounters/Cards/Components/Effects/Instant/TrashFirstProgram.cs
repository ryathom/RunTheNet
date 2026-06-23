using ryathom.RunTheNet.Encounters.Actions;
using System.Collections;
using ryathom.RunTheNet.Encounters.Zones;
using System.Collections.Generic;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class TrashFirstProgram : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            Program program = null;

            foreach (ServerSlot slot in EncounterManager.Instance.Server.Slots)
            {
                if (slot.Card != null)
                {
                    if (slot.Card is Program p)
                    {
                        program = p;
                        break;
                    }
                }
            }

            if (program == null) yield break;

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(program));

            EncounterManager.Instance.Server.ConsolidateServerSlots();
        }

        public IEffect Copy()
        {
            return new TrashFirstProgram();
        }
    }

    [System.Serializable]
    public class TrashTargetProgram : ITargetingEffect, IEffect
    {
        public Card Target;

        public IEnumerator Execute(Card source)
        {
            if (!TargetSelected()) yield break;

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(Target));
        }

        public List<Card> GetValidTargets(Card source)
        {
            List<Card> validTargets = new();

            foreach (Card card in EncounterManager.Instance.Server.Cards)
            {
                if (card is Program program)
                {
                    validTargets.Add(program);
                }
            }

            return validTargets;
        }

        public void SetTarget(Card target)
        {
            Target = target;
        }

        public bool TargetSelected()
        {
            return Target != null;
        }

        public IEffect Copy()
        {
            return new TrashTargetProgram();
        }
    }
}