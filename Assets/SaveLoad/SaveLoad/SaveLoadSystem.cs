using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class SaveLoadSystem : MonoBehaviour
    {
        public static PlayerData playerData = new PlayerData();

        public static SaveLoadSystem instance = null;

        // streaming assets is a folder that unity creates that we can use 
        // to load/save data in, in the folder it is in the project folder,
        // in a build, it is in the .exe's build folder
        private string FilePath => Application.streamingAssetsPath + "/playerData";

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            if (!Directory.Exists(Application.streamingAssetsPath))
                Directory.CreateDirectory(Application.streamingAssetsPath);

        }

        public void Save()
        {
            SaveBinary();
        }

        private void SaveBinary()
        {
            // This opens the 'river' between the RAM and the file.
            using (FileStream stream = new FileStream(FilePath + "_save", FileMode.OpenOrCreate))
            {
                // Like creating the boat that will carry the data from one point to another
                BinaryFormatter formatter = new BinaryFormatter();
                // Transports the data from the sum to the specified file, like freezing water
                // into ice.
                formatter.Serialize(stream, playerData);

            }
        }

        public void Load()
        {
            LoadBinary();
        }

        private void LoadBinary()
        {
            // If there is no save data, we shoudn't attempt to load it
            if (File.Exists(FilePath + ".save"))
                return;
            // This opens the 'river' between the RAM and the file.
            using (FileStream stream = new FileStream(FilePath + "_save", FileMode.Open))
            {
                // Like creating the boat that will carry the data from one point to another
                BinaryFormatter formatter = new BinaryFormatter();
                // Transports the data from the sum to the specified file to the RAM, like freezing water
                // into ice.
                playerData = formatter.Deserialize(stream) as PlayerData;
            }
        }

        //private void OnGUI()
        //{
        //    // GUI save button
        //    if (GUILayout.Button("Save"))
        //    {
        //        Save();
        //    }
        //    // GUI load button
        //    if (GUILayout.Button("Load"))
        //    {
        //        Load();
        //    }
        //}
    }
}