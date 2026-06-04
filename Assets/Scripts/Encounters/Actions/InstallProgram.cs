using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Player;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class InstallProgram : IAction
    {
        public Card Program {get; private set;}
        private Runner runner;

        public InstallProgram(Card program)
        {
            Program = program;
        }


        public IEnumerator Execute()
        {
            runner = EncounterManager.Instance.Runner;

            if (runner.Clicks <= 0) yield break;
            runner.SpendClicks(1);

            Program.Zone.RemoveCard(Program);
            runner.Rig.AddCard(Program);

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Program, EncounterManager.Instance.Server));
        }
    }
}