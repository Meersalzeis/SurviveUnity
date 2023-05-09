using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyableScript : MonoBehaviour
{
    /// <summary>
    /// Script for buyable options in buttons, intended to be customized by child scripts
    /// </summary>
    
    protected bool _isBought = false;
    [SerializeField] protected float _price;
    [SerializeField] protected Image _contentIcon;

    [Tooltip("The is relevant only for the prefab")]
    [SerializeField] TMP_Text _buyButtonLabel;
    [SerializeField] Image _lockedIcon;
    [SerializeField] Image _priceIcon;

    private void Start()
    {
        // TODO check save - is bought?


        // adjust button content
        if (_isBought)
        {
            SetBought();
        } // TODO else use proper color for button, rest is correct
    }

    public void OnButtonPressed()
    {
        if ( _isBought )
        {
            UseContent();
        } else
        {
            TryToBuy();
        }
    }

    private bool TryToBuy()
    {
        if (Globals.gdata.moneyTime < _price)
        {
            return false;
        } else
        {
            Globals.gdata.setMoneyTime(Globals.gdata.moneyTime - _price);
            _isBought = true;
            SetBought();
            // TODO save bought
            return true;
        }
    }

    private void SetBought()
    {
        _buyButtonLabel.text = "select";
        _lockedIcon.sprite = Globals.unlockedIcon;
    }

    // To be overwriten by scripts inheriting this
    public virtual void UseContent()
    {

    }
}
