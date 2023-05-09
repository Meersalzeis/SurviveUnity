using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A stage maanger for pre-listed hazards, usually tuned for specific soundtracks
/// Not planned to be realized in early alpha
/// </summary>
public class PremadeStageManager : MonoBehaviour
{
    // TODO just plain invoke the hazards in start with functions.
    [SerializeField]
    private List<Attack> attacks = new List<Attack>();
    private float timer = 0;


    private void Start()
    {
        // TODO start first attack
        // TODO list all attacks in order
    }

    // Here all attacks are checked
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        while (attacks[0].time <= timer)
        {
            MakeAttack(attacks[0]);
            attacks.RemoveAt(0);
        }
    }

    private void MakeAttack(Attack attack)
    {
        // TODO execute attack
    }

    private struct Attack
    {
        public float time;
        public GameObject hazard;
        public float rotation;
        public Vector2 position;
    }
}
