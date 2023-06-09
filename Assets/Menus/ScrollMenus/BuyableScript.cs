using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ScriptableObjectArchitecture;

public class BuyableScript : MonoBehaviour
{
    /// <summary>
    /// Script for buyable options in buttons, intended to be customized by child scripts
    /// </summary>
    
    protected bool _isBought = false;
    [SerializeField] protected float _price;
    [SerializeField] protected Image _contentIcon;

    [Tooltip("The is relevant only for the prefab")]
    [SerializeField] protected TMP_Text _buyButtonLabel;
    [SerializeField] protected Image _lockedIcon;
    [SerializeField] protected Image _priceIcon;

    [SerializeField] protected FloatVariable displayedMoneyTime;

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
            _isBought = true;
            SetBought();

            Globals.gdata.setMoneyTime(Globals.gdata.moneyTime - _price); // saves on its own
            displayedMoneyTime.Value = Globals.gdata.moneyTime;
            return true;
        }
    }

    protected void SetBought()
    {
        _buyButtonLabel.text = "select";
        _lockedIcon.sprite = Globals.unlockedIcon;
        SaveBought();
    }

    // To be overwriten by scripts inheriting this
    public virtual void UseContent()
    {

    }

    // To be overwriten by scripts inheriting this
    public virtual void SaveBought()
    {

    }
}
