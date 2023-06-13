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
        Debug.Log("heh? 1");
        Globals.Initialize();
        Debug.Log("heh? 2");

        Globals.modelList = modelList;
        Globals.particleSytemList = particleSystems;
        Globals.mostRecentLevel = mostRecentLevelToInitialize;
    }

}
