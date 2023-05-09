using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A scriptable object that stores all information
/// needed to set up a random level
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "Menu/LevelOption", order = 1)]
public class LevelOption : ScriptableObject
{
    public int LevelNr;
    public float costs;
    public Sprite Icon;
}
