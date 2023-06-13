using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer bgRenderer;

    private void Start()
    {
        Initialize( Globals.mostRecentLevel );
    }

    // Sets up the levels Background, the players model and particles
    private void Initialize(LevelOption lvlOption)
    {
        /**
        // Get parts for cursor
        int modelNr = Globals.gdata.modelSelected;
        GameObject cursorPrefab = Globals.modelList[modelNr];

        int particleNr = Globals.gdata.particlesSelected;
        ParticleSystem particleSystem = Globals.particleSytemList[particleNr];

        // Instantiate cursor 
        GameObject cursor = Instantiate(cursorPrefab, gameObject.transform);
        cursor.GetComponent<PlayerModel>().addParticles(particleSystem);
        // **/

        // Background
        //Debug.Log(lvlOption);
        bgRenderer.sprite = lvlOption.background;
        bgRenderer.transform.localScale = new Vector3(Globals.viewInUnits.x, Globals.viewInUnits.y, 1);
    }
}
