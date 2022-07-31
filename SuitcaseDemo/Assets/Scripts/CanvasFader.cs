using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFader : MonoBehaviour
{
    private CanvasGroup _canvasUIGroup;

    private float delayTime;
    private float _visibleAlpha = 1f;


    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Idle)
        {
            StartCoroutine(WaitAndFade(delayTime, false));
        }
        else
        {
            StartCoroutine(WaitAndFade(delayTime, true));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _canvasUIGroup = GetComponent<CanvasGroup>();
    }

    IEnumerator WaitAndFade(float delayTime, bool visible)
    {
        yield return new WaitForSeconds(delayTime);
        float startTime = Time.time;
        if (visible)
        {
            while (Time.time - startTime <= 1)
            {
                _canvasUIGroup.alpha = Mathf.Lerp(0, _visibleAlpha, Time.time - startTime);

                yield return 1;
            }
        }
        else
        {
            while (Time.time - startTime <= 1)
            {
                _canvasUIGroup.alpha = Mathf.Lerp(_visibleAlpha, 0, Time.time - startTime);

                yield return 1;
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
}
