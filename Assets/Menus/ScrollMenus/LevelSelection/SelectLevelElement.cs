using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A script that manages a single option in an element for scrolling lists, for levels.
/// </summary>

public class SelectLevelElement : BuyableScript
{
    [SerializeField] private LevelOption levelOption;

    public async override void UseContent()
    {
        Globals.mostRecentLevel = levelOption;
        Scenes.GoToScene(levelOption.levelNr); //TODO change to one instantiating Level for randoms
    }

    public override void SaveBought()
    {
        Globals.gdata.levelsUnlocked[levelOption.levelNr] = true;
    }

    public void Prime(LevelOption lvlToRepresent)
    {
        levelOption = lvlToRepresent;

        base._price = levelOption.costs;
        base._contentIcon.sprite = levelOption.icon;

        if (  Globals.gdata.levelsUnlocked[levelOption.levelNr]  )
        {
            base.SetBought();
        } else
        {
            base._buyButtonLabel.text = Globals.floatToMoneytime(base._price);
        }
    }
}
