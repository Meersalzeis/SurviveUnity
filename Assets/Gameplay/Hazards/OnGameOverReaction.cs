using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOverReaction : MonoBehaviour
{
    public void OnGameOver()
    {
        Scenes.GoToScene(5);
    }
}
