using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _previewScreen;
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _endGameText;
    [SerializeField] private GameObject _ballManagerObject;
    [SerializeField] private AudioSource _mainTheme;
    private static BallManager _ballManager;
    
    [SerializeField] private bool _isPreviewOn = true;
    [SerializeField] private int _quantityOfHealth = 3;
    private static int _leftPlayerActualCounter;
    private static int _rightPlayerActualCounter;

    void Awake() {
        BallActivity.SetActive(true);
        StartCoroutine(MakeAwake());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _rightPlayerActualCounter = 0;
        _leftPlayerActualCounter = 0;
    }

    public IEnumerator MakeAwake() {
        _ballManager = _ballManagerObject.GetComponent<BallManager>();
        if (_isPreviewOn) {
            yield return StartCoroutine(_previewScreen.GetComponent<PreviewActivity>().preview());
        }
        _ballManager.SpawnRandBall();
    }

    public static void SpawnRandBall() {
         _ballManager.SpawnRandBall();
    }

    public static void ReSpawnRandBallInTheSamePosition(GameObject spawnObject) {
        _ballManager.ReSpawnRandBallInTheSamePosition(spawnObject.transform.position);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }

        _scoreText.text = _rightPlayerActualCounter + ":" + _leftPlayerActualCounter;

        if (Math.Max(_leftPlayerActualCounter, _rightPlayerActualCounter) >= _quantityOfHealth) {
            EndGame();
        }
    }

    public void Pause() {
        if (_pauseScreen.activeSelf) {
            Cursor.visible = false;
            _pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        } else {
            Cursor.visible = true;
            _pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    } 

    public void EndGame() {
        Cursor.visible = true;
        BallActivity.SetActive(false);
        _endGameScreen.SetActive(true);

        if (_leftPlayerActualCounter > _rightPlayerActualCounter) {
            _endGameText.text = "RIGHT";
        } else {
            _endGameText.text = "LEFT";
        }
        
        _endGameText.text += " PLAYER WIN!";
    }

    public static void incrementLeftCounter() {
        _leftPlayerActualCounter += 1;
    }

    public static void incrementRightCounter() {
        _rightPlayerActualCounter += 1;
    }
}
