using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This singleton serves as a global reference storage
/// </summary>
public static class Globals
{

    // UI helper
    public static Sprite lockedIcon;
    public static Sprite unlockedIcon;

    // Viewport information
    public static Rect screenInPixels;
    
    public static Rect viewInUnits;
    public static float viewSizeInUnits;
    public static float x10th;
    public static float y10th;

    // Save and GameData
    public static GameData gdata;
    public static LevelOption mostRecentLevel;


    // Gameplay and Initializing thereof
    public static StageManager stageManager;
    public static ParticleSystem[] particleSytemList;
    public static GameObject[] modelList;


    public static void Initialize()
    {
        SaveSystem.Load();

        screenInPixels = Camera.main.pixelRect;

        // Camera.main.rect is not viewInUnits! It's not 0,0 to 1,1
        var origin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        var extend = Camera.main.ScreenToWorldPoint(new Vector3(screenInPixels.width, screenInPixels.height, 0));
        viewInUnits = new Rect( new Vector2(0,0) , new Vector2(extend.x-origin.x, extend.y-origin.y) );

        //Debug.Log("View is " + viewInUnits);

        x10th = (float)viewInUnits.width / 10;
        y10th = (float)viewInUnits.height / 10;
        viewSizeInUnits = viewInUnits.width * viewInUnits.height;

    }

    public static string floatToMoneytime(float moneyTime)
    {
        int mins = (int) Math.Floor( moneyTime / 60);
        double secs = (Math.Truncate( moneyTime * 100 ) / 100) % ( 60 ) ; // * 100 and / 10 to truncate to 2 places after comma

        return mins < 10 ?
            "0" + mins.ToString() + ":" + secs.ToString() :
            mins.ToString() + ":" + secs.ToString();
    }
}
