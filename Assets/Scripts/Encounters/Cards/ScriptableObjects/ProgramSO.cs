using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [CreateAssetMenu(fileName = "ProgramSO", menuName = "Scriptable Objects/Cards/ProgramSO")]
    public class ProgramSO : CardSO
    {
        
    }

    public enum ProgramType
    {
        Immediate,
        Icebreaker,
    }
}