
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Run
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private Button encounterButtonPrefab;
        [SerializeField] private Transform mapTransform;

        private int mapWidth = 5;
        private int mapHeight = 4;
        private float xDist = 450;
        private float yDist = 350;

        private List<List<Button>> map = new();

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Start()
        {
            GenerateEmptyMap();
        }


        // Game flow
        //---------------------------------------------------------------------------------------------------------
        public void StartEncounter(EncounterSO encounter)
        {
            RunManager.Instance.StartEncounter(encounter);
        }



        // Map generation
        //---------------------------------------------------------------------------------------------------------
        public void GenerateEmptyMap()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                List<Button> floor = new();

                for (int j = 0; j < mapWidth; j++)
                {
                    Button btn = Instantiate(encounterButtonPrefab, mapTransform);
                    btn.transform.SetLocalPositionAndRotation(new Vector2(j*xDist, i*yDist), Quaternion.identity);
                    btn.image.color = Color.grey;
                    TextMeshProUGUI tm = btn.GetComponentInChildren<TextMeshProUGUI>();
                    tm.text = "Empty";

                    btn.gameObject.SetActive(true);
                    floor.Add(btn);
                }

                map.Add(floor);
            }
        }
    }
}