using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A StageManager that fills the Stage with randomly generated Hazards.
/// </summary>
public class RandomStageManager : StageManager
{ 

    [SerializeField]
    protected int seed = 0;

    protected const float HAZARD_PERIOD_LENGTH = 12;
    protected const float CALM_PERIOD_LENGTH = 3;
    protected bool _isCalmPeriod = true;
    public bool _isRunning = true;

    [SerializeField] private GameEvent CalmPeriodStarts;
    [SerializeField] private GameEvent HazardPeriodStarts;

    [SerializeField] protected float _HazardsInHz = 0.5f;
    [SerializeField] protected GameObject LineHazard;
    [SerializeField] protected GameObject SideHazard;
    [SerializeField] protected GameObject DashHazard;
    protected float _hazardTimeLeft;

    protected float _moneyTimeThisRun = 0;
    protected float _periodTimeLeft;

    private void Start()
    {
        _periodTimeLeft = CALM_PERIOD_LENGTH;
        _hazardTimeLeft = _HazardsInHz;

        Random.InitState(seed);
        Invoke("SetHazardPeriod", CALM_PERIOD_LENGTH);
    }

    // Period Management

    private void SetHazardPeriod()
    {
        if (! _isRunning) return;

        _isCalmPeriod = false;
        HazardPeriodStarts.Raise();
        Invoke("SetCalmPeriod", HAZARD_PERIOD_LENGTH);
    }

    private void SetCalmPeriod()
    {
        if (!_isRunning) return;

        _isCalmPeriod = true;
        CalmPeriodStarts.Raise();
        Invoke("SetHazardPeriod", CALM_PERIOD_LENGTH );
    }

    // Hazard Period Management
    private void FixedUpdate()
    {
        if (! _isCalmPeriod)
        {
            // Hazard Timing
            _hazardTimeLeft -= Time.fixedDeltaTime;
            if (_hazardTimeLeft < 0)
            {
                _hazardTimeLeft += _HazardsInHz;
                SpawnHazard();
            }

            // Other Timers
            _moneyTimeThisRun += Time.fixedDeltaTime;
        }
    }

    private void SpawnHazard()
    {
        float roll = Random.Range(0, 1);

        if (roll < 1f)
        { // Spawn Line Hazard with random rotation
            Instantiate(LineHazard, GetPositionInScreen(), Quaternion.Euler(0, 0, Random.Range(0f, 360f))); // randomize 2D rotation (around z)
        } else // spawn SideHazard
        {
            // TODO spawnPositionSide
            // GameObject newHazard = Instantiate(LineHazard, spawnPositionSide, Quaternion.identity);
            // TODO ggf flip Hazard
        }

    }

    private Vector3 GetPositionInScreen()
    {
        Vector3 offset = new Vector3(-Globals.viewInUnits.width / 2, -Globals.viewInUnits.height / 2, 0);
        float randomX = Random.Range((float)Globals.x10th, Globals.viewInUnits.width - Globals.x10th);
        float randomY = Random.Range((float)Globals.y10th, Globals.viewInUnits.height - Globals.y10th);
        return new Vector3(randomX, randomY, 0) + offset;
    }
}
