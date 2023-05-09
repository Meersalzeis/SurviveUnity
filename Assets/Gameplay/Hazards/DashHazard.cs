using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Hazard with hight velocity that comes from the side of the screen, but displays a warning symbol where it appears
/// </summary>
public class DashHazard : Hazard
{
    [SerializeField] public float speed = 7.5f;

    private void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.up * speed * Time.deltaTime;
    }


    // TODO make warning on Start
    // TODO Set Dash position
    // TODO Make Dash speed
}
