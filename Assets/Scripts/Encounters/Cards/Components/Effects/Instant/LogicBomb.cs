using System.Collections;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class LogicBomb : IEffect
    {
        public IEffect Copy()
        {
            return new LogicBomb();
        }

        public IEnumerator Execute(Card source)
        {
            int strength;

            if (source is Program programSource)
            {
                strength = programSource.Strength;
            } else
            {
                yield break;
            }

            foreach (Card card in EncounterManager.Instance.Server.Cards)
            {
                if (card is Program program && program.Strength <= strength)
                {
                    EncounterManager.Instance.Actions.AddAction(new TrashCard(program));
                } else if (card is Ice ice && ice.Strength <= strength)
                {
                    EncounterManager.Instance.Actions.AddAction(new TrashCard(ice));
                }
            }

            yield return new EndAccess();
        }
    }
}