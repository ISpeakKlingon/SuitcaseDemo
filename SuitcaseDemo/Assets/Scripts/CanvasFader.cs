using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasFader : MonoBehaviour
{
    private CanvasGroup _canvasUIGroup;

    private float delayTime;
    private float _visibleAlpha = 1f;

    private string _header;
    private string _description;

    public TextMeshProUGUI HeaderText;
    public TextMeshProUGUI DescriptionText;

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
            // get text to display from Game Manager
            _header = GameManager.Instance.CurrentHeader;
            _description = GameManager.Instance.CurrentDescription;

            // change UI text to display the proper text
            HeaderText.text = _header;
            DescriptionText.text = _description;

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
