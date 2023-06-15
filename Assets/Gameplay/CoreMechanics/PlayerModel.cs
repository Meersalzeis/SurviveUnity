using ScriptableObjectArchitecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that is responsible for the player modell behaviour, particles and it's initialization
/// May be split at a later time
/// </summary>
/// 
public class PlayerModel : MonoBehaviour
{
    // TODO add initialization of modell and particles
    // TODO change shape with movement if modell allows for it
    // TODO calculate dash between movements

    // Update is called once per frame
    void Update()
    {
        if ( SystemInfo.operatingSystemFamily == OperatingSystemFamily.Other )
        {
            if (Input.touches.Length == 1)
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                // TODO Rotation
                transform.position = newPos;
            }
        } else
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // TODO Rotation
            transform.position = mousePos;
        }
    }

    void addParticles(ParticleSystem particleSystem)
    {
        throw new NotImplementedException();
    }
}
