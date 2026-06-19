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

            Debug.Log("Trashing " + Card.Name + " which is a " + Card.GetType().Name);

            if (Card is Program)
            {
                Debug.Log("Here because it's a program");
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Card, EncounterManager.Instance.Runner.Trash));
            } else if (Card is Hardware)
            {
                Debug.LogError("Hardware not expected to be trashed in prototype");
            } else
            {
                Debug.Log("Here because it's not a program");
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Card, EncounterManager.Instance.CorpTrash));
            }

            
        }
    }
}