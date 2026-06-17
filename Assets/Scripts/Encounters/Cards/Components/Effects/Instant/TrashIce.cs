using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class TrashIce : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            int pc = EncounterManager.Instance.Actions.ProgramCounter;
            Card nextCard = EncounterManager.Instance.Server.GetCardAtSlot(pc - 1);

            if (nextCard is Ice ice && source is Program program)
            {
                if (ice.Strength <= program.Strength)
                {
                    yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(ice));
                }
            }
        }

        public IEffect Copy()
        {
            return new TrashIce();
        }
    }
}