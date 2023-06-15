using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsInitializer : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleSystems;
    [SerializeField] private GameObject[] modelList;
    [SerializeField] private LevelOption mostRecentLevelToInitialize;

    void Awake()
    {
        if (Globals.wasInitialized) {
            return;
        }
        Globals.InternalInitialize();

        Globals.modelList = modelList;
        Globals.particleSytemList = particleSystems;
        Globals.mostRecentLevel = mostRecentLevelToInitialize;
    }

}
