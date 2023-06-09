using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A StageManager that fills the Stage with randomly generated Hazards.
/// </summary>
public class RandomStageManager : StageManager
{ 
    // I tried using _ to distinguish object valiables from local variables.
    // Does not make much of a difference while coding, so I've dropped the practice

    // I have also realized it would probably be better to initiate the spawn locations in the repective Hazard classes, but won't change it's not that important

    [SerializeField]
    protected int _seed = 0;

    protected const float HAZARD_PERIOD_LENGTH = 12;
    protected const float CALM_PERIOD_LENGTH = 3;
    protected bool _isCalmPeriod = true;
    protected bool _isRunning = true;

    [SerializeField] protected GameEvent CalmPeriodStarts;
    [SerializeField] protected GameEvent HazardPeriodStarts;

    [SerializeField] protected float _hazardsInHz = 0.5f;
    [SerializeField] protected GameObject _lineHazard;
    [SerializeField] protected GameObject _sideHazard;
    [SerializeField] protected GameObject _dashHazard;
    [SerializeField] protected GameObject _hazardWarning;
    protected float _hazardTimeLeft;

    protected float _moneyTimeThisRun = 0;
    protected float _periodTimeLeft;

    // =============== Initialization ===============

    private void Start()
    {
        _periodTimeLeft = CALM_PERIOD_LENGTH;
        _hazardTimeLeft = _hazardsInHz;

        Random.InitState(_seed);
        Invoke("SetHazardPeriod", CALM_PERIOD_LENGTH);

        // Make ratio horizontal to vertical of screen, needed for hazard placement
        ratioForHorizontal = Globals.viewInUnits.width / (Globals.viewInUnits.width + Globals.viewInUnits.height);
    }

    // =============== Period Management ===============

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
        base.clearHazards();
        CalmPeriodStarts.Raise();
        Invoke("SetHazardPeriod", CALM_PERIOD_LENGTH );
    }

    private void OnDestroy()
    {
        _isRunning = false;
    }

    // =============== Hazard Generation ===============
    private void FixedUpdate()
    {
        if (! _isCalmPeriod)
        {
            // Hazard Timing
            _hazardTimeLeft -= Time.fixedDeltaTime;
            if (_hazardTimeLeft < 0)
            {
                _hazardTimeLeft += _hazardsInHz;
                SpawnHazard();
            }

            // Other Timers
            _moneyTimeThisRun += Time.fixedDeltaTime;
        }
    }

    private void SpawnHazard()
    {
        // TODO balance the Hazard probabilities
        float roll = Random.Range(0f, 1f);

        if (roll < 0.334f) // TODO set to 0.333f to start balancing
        { 
            SpawnLinearHazard();
        } else if (roll < 0.667f) // TODO set to 0.666f to start balancing
        {
            SpawnSideHazard();
        } else
        {
            SpawnDashHazard();
            Debug.Log("DashHazard");
        }

    }


    // =============== spawn specific hazards =============== 

    private void SpawnLinearHazard()
    {
        // randomize 2D rotation (around z) wit Quaternion
        Instantiate(_lineHazard, GetPositionInScreen(), Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
    }

    private void SpawnSideHazard()
    {
        // Needed to generate trajectory
        Vector3 willCrossThisPoint = GetPositionInScreen();
        Vector3 justOutsideScreen = GetPositionJustOutsideScreen();

        GameObject newSideHazard = Instantiate(_sideHazard, justOutsideScreen, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        SideHazard newHazardScript = newSideHazard.GetComponent<SideHazard>();

        // Set velocity
        newHazardScript.velocity = (willCrossThisPoint - justOutsideScreen);
        newHazardScript.applySpeed();

        // Flip Sprite if it comes from right, not important for all sprites
        if (newHazardScript.flipsSpriteToCenter && justOutsideScreen.x > 0)
        {
            newSideHazard.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Rotation if given
        if (newHazardScript.rotates)
        {
            newHazardScript.rotationSpeed = Random.Range(-180, 180);
        }
    }

    private void SpawnDashHazard()
    {
        // Needed to generate trajectory
        Vector3 willCrossThisPoint = GetPositionInScreen();
        Vector3 justOutsideScreen = GetPositionJustOutsideScreen();
        Vector3 moveDirection = (willCrossThisPoint + justOutsideScreen);

        // Dash object
        GameObject newDashHazard = Instantiate(_dashHazard, justOutsideScreen, Quaternion.LookRotation(moveDirection) * Quaternion.Euler(0, 90, -90 ));
        DashHazard newHazardScript = newDashHazard.GetComponent<DashHazard>();
        // Delay to give players a chance to see the warning
        newDashHazard.transform.position += moveDirection.normalized * newHazardScript.GetSpeed();

        // Warning object
        Vector3 warningPosition = justOutsideScreen + moveDirection.normalized * -(Globals.x10th + Globals.y10th);
        GameObject newWarning = Instantiate(_hazardWarning, warningPosition, Quaternion.LookRotation(moveDirection) * Quaternion.Euler(0, 90, -90) );

        Debug.Log(newWarning + " and " + newDashHazard);
    }

    // =============== utility to spawn hazards =============== 

    private Vector3 GetPositionInScreen()
    {
        // Globals.x10th stands for 10th of Screen, in Units
        Vector3 offset = new Vector3(-Globals.viewInUnits.width / 2, -Globals.viewInUnits.height / 2, 0);
        float randomX = Random.Range((float) Globals.x10th, Globals.viewInUnits.width - Globals.x10th);
        float randomY = Random.Range((float) Globals.y10th, Globals.viewInUnits.height - Globals.y10th);
        return new Vector3(randomX, randomY, 0) + offset;
    }

    private float ratioForHorizontal;
    private Vector3 GetPositionJustOutsideScreen()
    {
        Vector3 returnVector = Vector3.zero;
        float roll = Random.Range(0, 1);
        // TODO make halfscreen value to simplify things
        if (roll < ratioForHorizontal)
        {
            // Random position on x, out of sight on y
            returnVector.x = Random.Range(-Globals.viewInUnits.width / 2 - Globals.x10th, Globals.viewInUnits.width / 2 + Globals.x10th);
            returnVector.y = (roll%0.2 < 0.1) ? 
                -Globals.y10th - Globals.viewInUnits.height / 2 :
                Globals.y10th + Globals.viewInUnits.height / 2 ;
        } else
        {
            // Random position on y, out of sight in x
            returnVector.y = Random.Range(-Globals.viewInUnits.height / 2 - Globals.y10th, Globals.viewInUnits.height / 2 + Globals.y10th);
            returnVector.x = (roll % 0.2 < 0.1) ?
                -Globals.x10th - Globals.viewInUnits.width / 2 :
                Globals.x10th + Globals.viewInUnits.width / 2;
        }
        return returnVector;
    }
}
