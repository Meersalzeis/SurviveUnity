using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer bgRenderer;

    // Start is called before the first frame update
    void Initialize(LevelOption lvlOption)
    {
        // Get parts for cursor
        int modelNr = Globals.gdata.modelSelected;
        GameObject cursorPrefab = Globals.modelList[modelNr];

        int particleNr = Globals.gdata.particlesSelected;
        ParticleSystem particleSystem = Globals.particleSytemList[particleNr];

        // Instantiate cursor 
        GameObject cursor = Instantiate(cursorPrefab, gameObject.transform);
        cursor.GetComponent<PlayerModel>().addParticles(particleSystem);


        // Background
        bgRenderer.sprite = lvlOption.background;
    }
}
