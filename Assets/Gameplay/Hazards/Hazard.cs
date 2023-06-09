using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

/// <summary>
/// The parent of all hazard classes, manages the collision and hazard management
/// </summary>
public class Hazard : MonoBehaviour
{
    [SerializeField]
    protected Collider2D collider;

    [SerializeField]
    protected GameEvent OnHitEvent;

    [SerializeField]
    protected ObjectGameEvent NewHazardEvent;

    protected void Start()
    {
        Globals.stageManager.registerHazard(this);
        //NewHazardEvent.Raise(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnHitEvent.Raise();
    }
}
