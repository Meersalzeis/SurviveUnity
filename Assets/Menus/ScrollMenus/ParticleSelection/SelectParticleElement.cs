using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A script that manages a single option in an element for scrolling lists, for particles.
/// </summary>

public class SelectParticleElement : BuyableScript
{
    [SerializeField] private int _particleNr;

    public override void UseContent()
    {
        Globals.gdata.particlesSelected = _particleNr;
    }

    public override void SaveBought()
    {
        Globals.gdata.particlesUnlocked[_particleNr] = true;
    }

    public void Prime(ParticleOption toPrimeWith)
    {
        _particleNr = toPrimeWith.particleNr;
        base._price = toPrimeWith.costs;
        base._contentIcon.sprite = toPrimeWith.Icon;

        if ( Globals.gdata.levelsUnlocked[_particleNr] )
        {
            base.SetBought();
        } else
        {
            base._buyButtonLabel.text = Globals.floatToMoneytime(base._price);
        }
    }
}

