namespace ryathom.RunTheNet.Encounters
{
    public class EncounterInfo
    {
        public int Trace;
        public int MaxTrace;

        public int CurrentTurn;
        public Phase CurrentPhase;

        public EncounterInfo()
        {
            Trace = 0;
            MaxTrace = 10;

            CurrentTurn = 0;
            CurrentPhase = new NullPhase();
        }
    }
}