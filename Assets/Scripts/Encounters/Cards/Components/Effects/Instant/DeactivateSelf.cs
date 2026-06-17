using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class DeactivateSelf : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            source.Deactivate();

            return null;
        }

        public IEffect Copy()
        {
            return new DeactivateSelf();
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