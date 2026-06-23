using ryathom.RunTheNet.Encounters.Actions;
using System.Collections;
using System.Collections.Generic;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class TrashTargetProgram : ITargetingEffect, IEffect
    {
        public Card Target;
        public string TargetPrompt;

        public TrashTargetProgram(string prompt)
        {
            TargetPrompt = prompt;
        }

        public IEnumerator Execute(Card source)
        {
            if (!TargetSelected()) yield break;

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(Target));

            EncounterManager.Instance.Server.ConsolidateServerSlots();

            Target = null;
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
            return new TrashTargetProgram(TargetPrompt);
        }

        public string TargetingText()
        {
            return TargetPrompt;
        }
    }
}