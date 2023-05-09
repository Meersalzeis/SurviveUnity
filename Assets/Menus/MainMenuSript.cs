using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Main Menu
/// </summary>

public class MainMenuSript : MonoBehaviour
{
    
    public void TestLevelPressed()
    {
        Scenes.GoToScene(5);
    }

    public void LevelSelectPressed()
    {
        Scenes.GoToScene(2);
    }

    public void ParticleSelectPressed()
    {
        Scenes.GoToScene(3);
    }

    public void ModellSelectPressed()
    {
        Scenes.GoToScene(4);
    }

    public void AboutPressed()
    {
        Scenes.GoToScene(1);
    }
}
