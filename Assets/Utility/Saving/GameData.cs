using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All GamaData that needs to be saved
/// </summary>

[System.Serializable]
public class GameData 
{
    public float moneyTime { get; private set; }

    public bool[] levelsUnlocked;
    public bool[] extraParticlesUnlocked;
    public bool[] extraModelsUnlocked;

    public float sfxVolume;
    public float musicVolume;


    public GameData()
    {
        // TODO change to read in later?
        Debug.Log("new Gamedata created");
        moneyTime = 100;

        levelsUnlocked = new bool[3];
        levelsUnlocked[0] = true;
        for (int i = 1; i < levelsUnlocked.Length; i++)
        {
            levelsUnlocked[i] = false;
        }

        sfxVolume = 1;
        musicVolume = 1;
    }

    internal bool isLevelUnlocked(int levelNr)
    {
        return levelsUnlocked[levelNr];
    }

    public bool setMoneyTime(float newVal)
    {
        moneyTime = newVal;
        SaveSystem.Save();
        return true;
    }
}
