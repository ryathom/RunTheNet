
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
        private int mapHeight = 10;
        private float xDist = 450;
        private float yDist = 350;
        private int numPaths = 3;

        private Vector2 cachedPointInput;
        private Vector2 cachedMapPosition;

        private float scrollSpeed = 0.01f;

        private List<List<Button>> map = new();

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Start()
        {
            GenerateEmptyMap();
            GeneratePaths();

            InputManager.Instance.OnMiddleClickAction += CachePointInput;
        }


        private void Update()
        {
            HandleMapMovement();
        }


        // Game flow
        //---------------------------------------------------------------------------------------------------------
        public void StartEncounter(EncounterSO encounter)
        {
            RunManager.Instance.StartEncounter(encounter);
        }

        public void HandleMapMovement()
        {
            if (InputManager.Instance.GetMiddleClick())
            {
                if (cachedPointInput != null)
                {
                    mapTransform.position = cachedMapPosition + InputManager.Instance.GetPointInput() - cachedPointInput;
                }
            }

            float scrollOffset = 1 + InputManager.Instance.GetScrollInput().y * scrollSpeed;

            if (scrollOffset != 1)
            {
                mapTransform.localScale *= scrollOffset;
            }
        }

        public void CachePointInput()
        {
            cachedPointInput = InputManager.Instance.GetPointInput();
            cachedMapPosition = mapTransform.position;
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

        public void GeneratePaths()
        {
            for (int i = 0; i < numPaths; i++)
            {
                GeneratePath();
            }
        }

        public void GeneratePath()
        {
            int x = Random.Range(0, mapWidth);
            Button startBtn = map[0][x];

            startBtn.image.color = Color.white;
            TextMeshProUGUI tm1 = startBtn.GetComponentInChildren<TextMeshProUGUI>();
            tm1.text = "Encounter";

            for (int i = 1; i < mapHeight; i++)
            {
                List<Button> floor = map[i];

                int offset = Random.Range(-1, 2);

                x += offset;
                x = Mathf.Clamp(x, 0, mapWidth-1);

                // Debug.Log("Floor " + i + ", room " + x);

                Button btn = floor[x];

                btn.image.color = Color.white;
                TextMeshProUGUI tm = btn.GetComponentInChildren<TextMeshProUGUI>();
                tm.text = "Encounter";
            }
        }
    }
}