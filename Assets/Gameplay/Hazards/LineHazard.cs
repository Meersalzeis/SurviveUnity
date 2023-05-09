using UnityEngine;
using DG.Tweening;
using ScriptableObjectArchitecture;

/// <summary>
/// A Hazard that drops a line over the screen.
/// </summary>
public class LineHazard : Hazard
{
    private Vector3 startScale;
    public float _fallingTime = 1f;
    private SpriteRenderer _mySpriteRenderer;

    // view methods as timeline

    private void Start()
    {
        base.Start(); //TODO check needed
        _mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Adjust scale of this hazard to screen size
        startScale = transform.localScale;
        startScale.x = Globals.viewSizeInUnits * 0.001f;

        // Animation of falling down
        transform.DOScaleX(0.5f * startScale.x, _fallingTime).From();
        _mySpriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.65f);
        _mySpriteRenderer.DOColor(new Color(0.2f, 0.2f, 0.2f, 0.8f), _fallingTime);

        Invoke("endFalling", _fallingTime);
    }

    void endFalling()
    {
        base.collider.enabled = true;
        _mySpriteRenderer.color = new Color(0f, 0f, 0f, 1f);
        _mySpriteRenderer.DOColor(new Color(0f, 0f, 0f, 0.8f), _fallingTime);
        Invoke("removeSelf", 1);
    }

    void removeSelf()
    {
        Globals.stageManager.unregisterHazard(this);
        Destroy(gameObject);
    }
}
