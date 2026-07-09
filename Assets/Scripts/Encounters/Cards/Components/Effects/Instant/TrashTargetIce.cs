using System.Collections;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class TrashTargetIce : ITargetingEffect, IEffect
    {
        public Card Target {get; private set;}
        public string TargetPrompt;

        public TrashTargetIce() {}

        public TrashTargetIce(string prompt)
        {
            TargetPrompt = prompt;
        }

        public IEnumerator Execute(Card source)
        {
            if (!TargetSelected()) yield break;

            if (Target is Ice ice && source is Program program)
            {
                if (ice.Strength <= program.Strength)
                {
                    yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(ice));
                }
            }

            Target = null;
        }

        public List<Card> GetValidTargets(Card source)
        {
            List<Card> validTargets = new();

            foreach (Card card in EncounterManager.Instance.Server.Cards)
            {
                if (card is Ice ice)
                {
                    validTargets.Add(ice);
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
            return new TrashTargetIce(TargetPrompt);
        }

        public string TargetingText()
        {
            return TargetPrompt;
        }
    }
}