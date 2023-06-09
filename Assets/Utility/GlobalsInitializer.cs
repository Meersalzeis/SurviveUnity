using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsInitializer : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleSystems;
    [SerializeField] private GameObject[] modelList;

    void Awake()
    {
        Globals.Initialize();

        Globals.modelList = modelList;
        Globals.particleSytemList = particleSystems;
    }

}
