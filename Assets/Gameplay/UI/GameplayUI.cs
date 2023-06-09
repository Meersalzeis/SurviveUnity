using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI during Gameplay
/// </summary>
public class GameplayUI : MonoBehaviour
{
    private bool isCalmPeriod = true;
    private float thisRoundMoneyTime = 0;

    [SerializeField]
    private TMP_Text timelabel;


    public void OnCalmPeriodStarts()
    {
        isCalmPeriod = true;
    }

    public void OnHazardPeriodStarts()
    {
        isCalmPeriod = false;
    }

    public void OnGameOver()
    {
        Debug.Log("New gdata moneyTime to be set");
        Globals.gdata.setMoneyTime( Globals.gdata.moneyTime + thisRoundMoneyTime);
        Debug.Log("Gdata moneytime is now " + Globals.gdata.moneyTime);
    }

    private void FixedUpdate()
    {
        if (! isCalmPeriod)
        {
            thisRoundMoneyTime += Time.fixedDeltaTime;
            timelabel.text = Globals.floatToMoneytime(thisRoundMoneyTime);
        }
    }
}
