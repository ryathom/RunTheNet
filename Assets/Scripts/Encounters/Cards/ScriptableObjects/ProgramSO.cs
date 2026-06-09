using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [CreateAssetMenu(fileName = "ProgramSO", menuName = "Scriptable Objects/Cards/ProgramSO")]
    public class ProgramSO : CardSO
    {
        [SerializeReference, SubclassSelector]
        public ICost Cost = new ClickCost(1);   
    }

    public enum ProgramType
    {
        Immediate,
        Icebreaker,
    }
}