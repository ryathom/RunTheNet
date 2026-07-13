using System.Collections.Generic;

namespace ryathom.RunTheNet.Run.Serialization
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData current;
        public static SaveData Current
        {
            get
            {
                current ??= new SaveData();

                return current;
            }
            set
            {
                current = value;
            }
        }

        public MapSaveData mapSaveData;
    }

    [System.Serializable]
    public class MapSaveData
    {
        public List<MapNodeData> map = new();
    }

    [System.Serializable]
    public class MapNodeData
    {
        public int xPosition;
        public int yPosition;

        public EncounterType encounterType;
        public EncounterSO encounterSO;

        public List<MapNodeData> connections = new();
    }
}