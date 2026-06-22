using ryathom.RunTheNet.Encounters.Actions;
using System.Collections;
using ryathom.RunTheNet.Encounters.Zones;

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

    // [System.Serializable]
    // public class TrashTargetProgram : ITargetingEffect, IEffect
    // {
    //     public IEnumerator Execute(Card source)
    //     {
    //         throw new System.NotImplementedException();
    //     }

    //     public List<Card> GetValidTargets(Card source)
    //     {
    //         List<Card> validTargets = new();

    //         foreach (Card card in EncounterManager.Instance.Server.Cards)
    //         {
    //             if (card is Program program)
    //             {
    //                 validTargets.Add(program);
    //             }
    //         }

    //         return validTargets;
    //     }

    //     public void SetTarget(Card target)
    //     {
    //         throw new System.NotImplementedException();
    //     }

    //     public bool TargetSelected()
    //     {
    //         throw new System.NotImplementedException();
    //     }

    //     public IEffect Copy()
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }
}