
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Run
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private EncounterButton encounterButtonPrefab;
        [SerializeField] private Transform mapTransform;
        [SerializeField] private Transform mapButtonsTransform;
        [SerializeField] private Transform mapLinesTransform;

        [SerializeField] private Sprite lineImage;

        private int mapWidth = 5;
        private int mapHeight = 10;
        private float xDist = 450;
        private float yDist = 350;
        private int numPaths = 3;
        private float lineWidth = 50;

        private Vector2 cachedPointInput;
        private Vector2 cachedMapPosition;

        private float scrollSpeed = 0.01f;

        private List<List<EncounterButton>> map = new();

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Start()
        {
            GenerateEmptyMap();
            GeneratePaths();
            GenerateConnections();

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
                List<EncounterButton> floor = new();

                for (int j = 0; j < mapWidth; j++)
                {
                    EncounterButton btn = Instantiate(encounterButtonPrefab, mapButtonsTransform);
                    btn.transform.SetLocalPositionAndRotation(new Vector2(j*xDist, i*yDist), Quaternion.identity);
                    btn.SetAppearance("Empty", Color.grey);

                    btn.gameObject.SetActive(false);
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
            EncounterButton startBtn = map[0][x];

            startBtn.SetAppearance("Encounter", Color.white);
            startBtn.gameObject.SetActive(true);

            EncounterButton prevBtn = startBtn;

            for (int i = 1; i < mapHeight; i++)
            {
                List<EncounterButton> floor = map[i];

                int offset = Random.Range(-1, 2);

                x += offset;
                x = Mathf.Clamp(x, 0, mapWidth-1);

                EncounterButton btn = floor[x];
                btn.SetAppearance("Encounter", Color.white);
                btn.gameObject.SetActive(true);

                if (prevBtn.Connections.Contains(btn) == false)
                {
                    prevBtn.Connections.Add(btn);
                }

                prevBtn = btn;
            }
        }

        public void GenerateConnections()
        {
            foreach (List<EncounterButton> floor in map)
            {
                foreach (EncounterButton button in floor)
                {
                    if (button.Connections == null) continue;

                    foreach (EncounterButton connection in button.Connections)
                    {
                        MakeLine(button.transform.localPosition, connection.transform.localPosition, Color.grey);
                    }
                }
            }
        }

        void MakeLine(Vector3 a, Vector3 b, Color col) {
            GameObject NewObj = new();
            Image NewImage = NewObj.AddComponent<Image>();
            NewImage.sprite = lineImage;
            NewImage.color = col;
            RectTransform rect = NewObj.GetComponent<RectTransform>();
            rect.SetParent(mapLinesTransform);
            rect.localScale = Vector3.one;

            rect.localPosition = (a + b) / 2;
            Vector3 dif = a - b;
            rect.sizeDelta = new Vector3(dif.magnitude, lineWidth);
            rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
    }
    }
}