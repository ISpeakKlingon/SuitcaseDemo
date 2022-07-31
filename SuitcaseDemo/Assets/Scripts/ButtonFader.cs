using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFader : MonoBehaviour
{
    public float buttonAlpha = 40f;
    private float _maxAlpha = 255f;
    private float _visibleAlpha;
    public float delayTime;

    [SerializeField] private Renderer button;

    private Color _color;

    //outline variables
    [SerializeField] private Outline outline;
    private Color _outlineColor;
    private float _visibleOutlineAlpha;
    public float outlineAlpha = 255f;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        if(state == GameManager.GameState.Idle)
        {
            StartCoroutine(WaitAndFade(delayTime, true));
        }
        else
        {
            StartCoroutine(WaitAndFade(delayTime, false));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //get reference to outline script on button model
        outline = GetComponentInChildren<Outline>();
        _outlineColor = outline.OutlineColor;
        _outlineColor.a = outlineAlpha / _maxAlpha;
        _visibleOutlineAlpha = _outlineColor.a;
        outline.OutlineColor = _outlineColor;

        _color = button.material.color;
        _color.a = buttonAlpha/_maxAlpha;
        _visibleAlpha = _color.a;
        button.material.color = _color;
    }

    IEnumerator WaitAndFade(float delayTime, bool visible)
    {
        yield return new WaitForSeconds(delayTime);
        float startTime = Time.time;
        if (visible)
        {
            while (Time.time - startTime <= 1)
            {
                _color.a = Mathf.Lerp(0, _visibleAlpha, Time.time - startTime);
                button.material.color = _color;

                // outline fade
                _outlineColor.a = Mathf.Lerp(0, _visibleOutlineAlpha, Time.time - startTime);
                outline.OutlineColor = _outlineColor;

                yield return 1;
            }
        }
        else
        {
            while (Time.time - startTime <= 1)
            {
                _color.a = Mathf.Lerp(_visibleAlpha, 0, Time.time - startTime);
                button.material.color = _color;

                // outline fade
                _outlineColor.a = Mathf.Lerp(_visibleOutlineAlpha, 0, Time.time - startTime);
                outline.OutlineColor = _outlineColor;

                yield return 1;
            }
        }
    }

    private void OnDestroy()
    {
        Destroy(button.material);
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
}
