using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class TrashCard : IAction
    {
        public Card Card {get; private set;}

        public TrashCard() {}

        public TrashCard(Card card)
        {
            Card = card;
        }

        public IEnumerator Execute()
        {
            if (Card == null) yield break;

            if (Card is Program)
            {
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Card, EncounterManager.Instance.Runner.Trash));
            } else if (Card is Hardware)
            {
                Debug.LogError("Hardware not expected to be trashed in prototype");
            } else
            {
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Card, EncounterManager.Instance.CorpTrash));
            }

            
        }
    }
}