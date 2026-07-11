
using System.Collections.Generic;
using ryathom.RunTheNet.Run.Serialization;
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

        [SerializeField] private EncounterSO testEncounter;

        [SerializeField] private Sprite lineImage;

        private int mapWidth = 5;
        private int mapHeight = 10;
        private float xDist = 450;
        private float yDist = 350;
        private int numPaths = 3;
        private float lineWidth = 50;

        private Vector2 cachedPointInput;
        private Vector2 cachedMapPosition;

        private float scrollSpeed = -10f;

        private List<List<EncounterButton>> map = new();
        private List<List<EncounterButton>> paths = new();

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Start()
        {
            if (SaveData.Current.mapSaveData == null)
            {
                GenerateEmptyMap();
                GeneratePaths();
                SaveMapData();
                GenerateConnections();
            } else
            {
                GenerateEmptyMap();
                LoadMapData();
                Debug.Log(RunManager.Instance);
                UpdateMapAppearance(RunManager.Instance.CurrentPosition);
                GenerateConnections();
            }

            

            InputManager.Instance.OnMiddleClickAction += CachePointInput;
        }


        private void Update()
        {
            HandleMapMovement();
        }


        // Navigation
        //---------------------------------------------------------------------------------------------------------
        public void HandleMapMovement()
        {
            // if (InputManager.Instance.GetMiddleClick())
            // {
            //     if (cachedPointInput != null)
            //     {
            //         mapTransform.position = cachedMapPosition + InputManager.Instance.GetPointInput() - cachedPointInput;
            //     }
            // }

            // float scrollOffset = 1 + InputManager.Instance.GetScrollInput().y * scrollSpeed;

            // if (scrollOffset != 1)
            // {
            //     mapTransform.localScale *= scrollOffset;
            // }

            mapTransform.Translate(InputManager.Instance.GetScrollInput() * scrollSpeed);
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
            List<EncounterButton> path = new();

            int x = Random.Range(0, mapWidth);
            EncounterButton startBtn = map[0][x];

            startBtn.SetCoords(new Vector2Int(x, 0));
            startBtn.SetAppearance("Encounter", Color.white);
            startBtn.SetEncounterSO(testEncounter);
            startBtn.gameObject.SetActive(true);
            path.Add(startBtn);

            EncounterButton prevBtn = startBtn;

            for (int i = 1; i < mapHeight; i++)
            {
                List<EncounterButton> floor = map[i];

                int offset = Random.Range(-1, 2);

                x += offset;
                x = Mathf.Clamp(x, 0, mapWidth-1);
                EncounterButton btn = floor[x];
                btn.SetCoords(new Vector2Int(x, i));

                int iterations = 0;

                while(CheckForCrossover(prevBtn, btn, path))
                {
                    iterations += 1;

                    if (iterations >= 1000)
                    {
                        Debug.LogError("Map generation failed");
                        Debug.Log(prevBtn.Coords);
                        return;
                    }

                    offset = Random.Range(-1, 2);
                    x += offset;
                    x = Mathf.Clamp(x, 0, mapWidth-1);
                    btn = floor[x];
                    btn.SetCoords(new Vector2Int(x, i));
                }

                btn.SetAppearance("Encounter", Color.grey);
                btn.SetEncounterSO(testEncounter);
                btn.gameObject.SetActive(true);
                path.Add(btn);

                if (prevBtn.Connections.Contains(btn) == false)
                {
                    prevBtn.Connections.Add(btn);
                }

                prevBtn = btn;
            }

            paths.Add(path);
        }

        public bool CheckForCrossover(EncounterButton btn1, EncounterButton btn2, List<EncounterButton> currentPath)
        {
            foreach (List<EncounterButton> path in paths)
            {
                if (path == currentPath) continue;

                EncounterButton pathBtn1 = path[btn1.Coords.y];
                EncounterButton pathBtn2 = path[btn2.Coords.y];

                if (pathBtn1.Coords.x > btn1.Coords.x && pathBtn2.Coords.x < btn2.Coords.x)
                {
                    return true;
                } else if (pathBtn1.Coords.x < btn1.Coords.x && pathBtn2.Coords.x > btn2.Coords.x)
                {
                    return true;
                }
            }

            return false;
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

        public void UpdateMapAppearance(Vector2 pos)
        {
            EncounterButton btn = map[(int)pos.y][(int)pos.x];

            foreach (List<EncounterButton> floor in map)
            {
                foreach (EncounterButton button in floor)
                {
                    button.SetColor(Color.grey);
                }
            }

            btn.SetColor(Color.lightGray);

            foreach (EncounterButton connection in btn.Connections)
            {
                connection.SetColor(Color.white);
            }
        }

        public void MakeLine(Vector3 a, Vector3 b, Color col) {
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

        // Serialization
        // -------------------------------------------------------------------------------------------
        public void SaveMapData()
        {
            SaveData.Current.mapSaveData = new();

            Dictionary<MapNodeData, EncounterButton> dict1 = new();
            Dictionary<EncounterButton, MapNodeData> dict2 = new();

            foreach (List<EncounterButton> floor in map)
            {
                foreach (EncounterButton button in floor)
                {
                    if (button.EncounterSO != null)
                    {
                        MapNodeData data = new()
                        {
                            xPosition = (int)button.Coords.x,
                            yPosition = (int)button.Coords.y,
                            encounterSO = button.EncounterSO
                        };

                        dict1.Add(data, button);
                        dict2.Add(button, data);
                        SaveData.Current.mapSaveData.map.Add(data);
                    }
                }
            }

            foreach (MapNodeData node in SaveData.Current.mapSaveData.map)
            {
                EncounterButton button = dict1[node];

                foreach (EncounterButton connection in button.Connections)
                {
                    node.connections.Add(dict2[connection]);
                }
            }
        }

        public void LoadMapData()
        {
            foreach (MapNodeData node in SaveData.Current.mapSaveData.map)
            {
                EncounterButton btn = map[node.yPosition][node.xPosition];

                btn.SetAppearance("Encounter", Color.grey);
                btn.SetEncounterSO(node.encounterSO);
                btn.SetCoords(new (node.xPosition, node.yPosition));
                btn.gameObject.SetActive(true);

                foreach (MapNodeData connection in node.connections)
                {
                    EncounterButton btnConnection = map[connection.yPosition][connection.xPosition];
                    btn.Connections.Add(btnConnection);
                }
            }
        }
    }
}