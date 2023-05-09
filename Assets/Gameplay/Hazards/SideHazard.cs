using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Hazard with slow velocity that comes from the side of the screen
/// </summary>
public class SideHazard : Hazard
{
    // TODO make speed dependand on ScreenSizeInUnits
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Vector3 velocity = new Vector3(1,1,0);

    private void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0,0, rotationSpeed * Time.fixedDeltaTime);
    }
}
