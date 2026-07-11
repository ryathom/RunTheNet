using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Run
{
    public class EncounterButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        public EncounterSO EncounterSO {get; private set;}
        public Vector2Int Coords {get; private set;}

        public List<EncounterButton> Connections {get; private set;}

        public void Awake()
        {
            Connections = new();
            button.onClick.AddListener(StartEncounter);
        }

        public void StartEncounter()
        {
            RunManager.Instance.StartEncounter(EncounterSO, this);
        }


        public void SetEncounterSO(EncounterSO encounterSO)
        {
            EncounterSO = encounterSO;
        }

        public void SetCoords(Vector2Int coords)
        {
            Coords = coords;
        }

        public void AddConnection(EncounterButton connection)
        {
            Connections.Add(connection);
        }

        public void SetAppearance(string name, Color color)
        {
            TextMeshProUGUI tm = button.GetComponentInChildren<TextMeshProUGUI>();
            tm.text = name;

            button.image.color = color;
        }

        public void SetColor(Color color)
        {
            button.image.color = color;
        }
    }
}