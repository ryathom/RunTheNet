using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class DrawCardEffect : IEffect
    {
        public IEnumerator Execute()
        {
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new DrawCard());
        }

        public IEffect Copy()
        {
            return new DrawCardEffect();
        }
    }
}