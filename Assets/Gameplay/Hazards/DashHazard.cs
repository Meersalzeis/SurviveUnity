using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

/// <summary>
/// A Hazard with hight velocity that comes from the side of the screen, but displays a warning symbol where it appears
/// </summary>
public class DashHazard : Hazard
{
    [SerializeField]
    private FloatReference moveSpeed;

    private void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.up * moveSpeed.Value * Time.deltaTime;
    }

    public float GetSpeed()
    {
        return moveSpeed.Value;
    }


    // TODO make warning on Start
    // TODO Set Dash position
    // TODO Make Dash speed
}
