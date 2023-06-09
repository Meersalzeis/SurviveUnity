using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A scriptable object that stores all information
/// needed to set up a particle system for the player model
/// </summary>
[CreateAssetMenu(fileName = "ParticleOption", menuName = "Menu/ParticleOption")]
public class ParticleOption : ScriptableObject
{ 
    public int particleNr;
    public float costs;
    public Sprite Icon;
}

