using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFader : MonoBehaviour
{
    public float buttonAlpha = 255f;
    private float _maxAlpha = 255f;
    private float _visibleAlpha;
    public float delayTime;

    [SerializeField] private Renderer button;

    private Color _color;

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
        _color = button.material.color;
        _color.a = buttonAlpha/_maxAlpha;
        _visibleAlpha = _color.a;
        button.material.color = _color;
    }

    /*public void FadeOutButton()
    {
        _color.a = Mathf.Lerp(buttonAlpha, 0, 1f);
    }

    public void FadeInButton()
    {
        _color.a = Mathf.Lerp(0, buttonAlpha, 1f);
    }*/

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

                yield return 1;
            }
        }
        else
        {
            while (Time.time - startTime <= 1)
            {
                _color.a = Mathf.Lerp(_visibleAlpha, 0, Time.time - startTime);
                button.material.color = _color;

                yield return 1;
            }
        }

        /*if (visible)
        {
            int i = 0;

            while (i < 255)
            {
                _color.a = _color.a + 1;
                button.material.color = _color;
                i = i + 1;
                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            int i = 255;

            while (i < 0)
            {
                _color.a = _color.a + 1;
                button.material.color = _color;
                i = i + 1;
                yield return new WaitForSeconds(1f);
            }
        }*/
    }

    private void OnDestroy()
    {
        Destroy(button.material);
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
}
