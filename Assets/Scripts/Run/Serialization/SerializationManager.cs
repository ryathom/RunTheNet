using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace ryathom.RunTheNet.Run.Serialization
{
    public class SerializationManager
    {
        public static string SAVE_PATH = Application.persistentDataPath + "/Saves/";

        public static bool Save(string savePath, SaveData saveData)
        {
            XmlSerializer serializer = GetXmlSerializer();

            if (!Directory.Exists(SAVE_PATH))
            {
                Directory.CreateDirectory(SAVE_PATH);
            }

            FileStream file = File.Create(savePath);
            serializer.Serialize(file, saveData);
            file.Close();
            
            return true;
        }

        public static SaveData Load(string path)
        {
            if (!File.Exists(path)) return null;

            XmlSerializer serializer = GetXmlSerializer();
            FileStream file = File.Open(path, FileMode.Open);

            try
            {
                SaveData save = serializer.Deserialize(file) as SaveData;
                file.Close();
                return save;
            }
            catch
            {
                Debug.LogErrorFormat("Failed to load file at {0}", path);
                file.Close();
                return null;
            }
        }

        public static XmlSerializer GetXmlSerializer()
        {
            XmlSerializer serializer = new(typeof(SaveData));

            return serializer;
        }
}
}