

/// <summary>
/// All GamaData that needs to be saved
/// </summary>

[System.Serializable]
public class GameData 
{
    public float moneyTime { get; private set; }

    public bool[] levelsUnlocked;
    public bool[] particlesUnlocked;
    public bool[] modelsUnlocked;

    public int particlesSelected;
    public int modelSelected;

    public float sfxVolume;
    public float musicVolume;


    public GameData()
    {
        moneyTime = 0;

        levelsUnlocked = new bool[10];
        particlesUnlocked = new bool[10];
        modelsUnlocked = new bool[10];

        for (int i = 1; i < levelsUnlocked.Length; i++)
        {
            levelsUnlocked[i] = false;
        }

        particlesSelected = 0;
        modelSelected = 0;

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
        return true;
    }

    public void SaveProgress()
    {
        SaveSystem.Save();
    }

}
