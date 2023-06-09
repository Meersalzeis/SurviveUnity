using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A scriptable object that stores all information
/// needed to set up a level
/// </summary>
[CreateAssetMenu(fileName = "LevelOption", menuName = "Menu/LevelOption", order = 1)]
public class LevelOption : ScriptableObject
{
    public int levelNr;
    public float costs;
    public Sprite icon;
    public Sprite background;
}
