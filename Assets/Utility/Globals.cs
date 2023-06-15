using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This singleton serves as a global reference storage
/// </summary>
public static class Globals
{
    public static bool wasInitialized = false;

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


    public static void InternalInitialize()
    {
        wasInitialized = true;
        SaveSystem.Load();

        // Screen Dimension Data
        screenInPixels = Camera.main.pixelRect;

        // Camera.main.rect is not viewInUnits! It's not 0,0 to 1,1
        var origin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        var extend = Camera.main.ScreenToWorldPoint(new Vector3(screenInPixels.width, screenInPixels.height, 0));
        Debug.Log("ScreenInPixels = " + screenInPixels + " makes origin&extend " + origin + " and " + extend);
        viewInUnits = new Rect(new Vector2(0, 0), new Vector2(extend.x - origin.x, extend.y - origin.y));

        //Debug.Log("View is " + viewInUnits);

        x10th = (float) viewInUnits.width / 10;
        y10th = (float) viewInUnits.height / 10;
        viewSizeInUnits = viewInUnits.width * viewInUnits.height;

        Debug.Log("Globals Initializd");
    }

    public static string floatToMoneytime(float moneyTime)
    {
        int mins = (int) Math.Floor( moneyTime / 60) ;
        int secs = (int) Math.Truncate( moneyTime % 60 ) ; // round down to full numbers
        string moneyTimeMinutesString = mins < 10 ? "0" + mins.ToString() : mins.ToString();
        string moneyTimeSecondsString = secs < 10 ? "0" + secs.ToString() : secs.ToString();
        return moneyTimeMinutesString + ":" + moneyTimeSecondsString;
    }
}
