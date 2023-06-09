using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

/// <summary>
/// A Hazard with slow velocity that comes from the side of the screen
/// </summary>
public class SideHazard : Hazard
{
    [SerializeField]
    private FloatReference moveSpeed;

    // TODO make speed dependand on ScreenSizeInUnits
    public float rotationSpeed = 1f;
    public Vector3 velocity = new Vector3(1,1,0);
    public bool rotates = true;
    public bool flipsSpriteToCenter = false;

    private void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
        transform.Rotate( 0, 0, rotationSpeed * Time.fixedDeltaTime);
    }

    public void applySpeed()
    {
        velocity = velocity.normalized * moveSpeed.Value;
    }
}
