using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that manages a single option in an element for scrolling lists
/// </summary>

public class SelectLevelElement : BuyableScript
{
    [SerializeField] private int _levelNr;

    public override void UseContent()
    {
        Scenes.GoToScene(_levelNr);
    }

    public void Prime(LevelOption toPrimeWith)
    {
        _levelNr = toPrimeWith.LevelNr;
        base._price = toPrimeWith.costs;
        base._contentIcon.sprite = toPrimeWith.Icon;

        base._isBought = Globals.gdata.isLevelUnlocked(_levelNr);
    }
}
