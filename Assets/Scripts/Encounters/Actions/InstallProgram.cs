using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Player;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class InstallProgram : IAction
    {
        public Card Program {get; private set;}
        public ServerSlot Slot {get; private set;}
        private Runner runner;

        public InstallProgram(Card program, ServerSlot slot)
        {
            Program = program;
            Slot = slot;
        }


        public IEnumerator Execute()
        {
            runner = EncounterManager.Instance.Runner;

            if (runner.Clicks <= 0) yield break;
            runner.SpendClicks(1);

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Program, EncounterManager.Instance.Server, Slot));
        }
    }
}