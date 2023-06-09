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
    // Debug.Log(Application.persistentDataPath);

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

        // DEBUG VALUES
        Globals.gdata.levelsUnlocked[0] = false;
        Globals.gdata.levelsUnlocked[1] = false;
        Globals.gdata.levelsUnlocked[2] = false;
        Globals.gdata.levelsUnlocked[3] = true;
        Globals.gdata.levelsUnlocked[4] = false;
        Globals.gdata.levelsUnlocked[5] = false;

        Globals.gdata.setMoneyTime(10000f);
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.binary";
    }
}
