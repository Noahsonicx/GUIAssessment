using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad
{
    public static void Load()
    {
       /*
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
            gameData = formatter.Deserialize(stream) as GameData;

        }
        */
    }
}
