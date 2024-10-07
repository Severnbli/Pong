using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _previewScreen;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    [SerializeField] private const bool _isPreviewOn = true;
    [SerializeField] private int _quantityOfHealth = 3;
    private static int _leftPlayerActualCounter = 0;
    private static int _rightPlayerActualCounter = 0;

    void Awake() {
        
        StartCoroutine(MakeAwake());
    }

    public IEnumerator MakeAwake() {
        if (_isPreviewOn) {
            yield return StartCoroutine(_previewScreen.GetComponent<PreviewActivity>().preview());
        }

        BallManager.SpawnRandBall();
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }

        _scoreText.text = _leftPlayerActualCounter + ":" + _rightPlayerActualCounter;

        if (Math.Max(_leftPlayerActualCounter, _rightPlayerActualCounter) >= _quantityOfHealth) {
            _leftPlayerActualCounter = _rightPlayerActualCounter = 0;
        }
    }

    public void Pause() {
        if (_pauseScreen.activeSelf) {
            _pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        } else {
            _pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    } 

    public static void incrementLeftCounter() {
        _leftPlayerActualCounter += 1;
    }

    public static void incrementRightCounter() {
        _rightPlayerActualCounter += 1;
    }
}
