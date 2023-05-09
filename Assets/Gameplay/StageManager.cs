using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class contains the MINIMAL requirements to work as a stage manager
/// </summary>
public class StageManager : MonoBehaviour
{
    [SerializeField]
    private List<Hazard> hazards = new List<Hazard>();

    protected void Awake()
    {
        Globals.stageManager = this;
    }

    public void registerHazard(Hazard newHazard)
    {
        hazards.Add(newHazard);
    }

    public void unregisterHazard(Hazard oldHazard)
    {
        hazards.Remove(oldHazard);
    }

    protected void clearHazards()
    {
        foreach ( Hazard haz in hazards)
        {
            // TODO special effect with smoke?
            Destroy( haz.gameObject );
        }
        hazards = new List<Hazard>();
    }
}
