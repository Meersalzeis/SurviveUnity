using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// A way to save and load GameData objects, in form of static methods
/// </summary>
public static class SaveSystem
{
    // https://www.youtube.com/watch?v=a4ImOZMPjvQ&ab_channel=Quick%27nDirty

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, Globals.gdata);
        fs.Close();
    }

    public static void Load()
    {
        if (!File.Exists(GetPath()))
        {
            Debug.Log("Made new Game Data");
            Globals.gdata = new GameData();
            Save();
        } else
        {
            Debug.Log("Old GameData found");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        Globals.gdata = formatter.Deserialize(fs) as GameData;
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.binary";
    }
}
