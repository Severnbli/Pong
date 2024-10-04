using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static String _leftPlayerKey = "space";
    [SerializeField] private static String _rightPlayerKey = "enter";
    [SerializeField] private TextMeshProUGUI _scoreBoard;
    [SerializeField] private TextMeshProUGUI _endScreenText;
    [SerializeField] private GameObject _endScreen;
    private static int _leftCounter = 0;
    private static int _rightCounter = 0; 

    void FixedUpdate()
    {
        _scoreBoard.text = _rightCounter + ":" + _leftCounter;

        if (Math.Max(_leftCounter, _rightCounter) == 3) {
            endGame();
        }
    }

    public void endGame() {
        _endScreen.SetActive(true);

        Time.timeScale = 0.0f;
        
        if (_rightCounter > _leftCounter) {
            _endScreenText.text = "LEFT";
        } else {
            _endScreenText.text = "RIGHT";
        }

        _endScreenText.text += " PLAYER WIN!";
    }

    public static void incrementRightCounter() {
        _rightCounter++;
    }

    public static void incrementLeftCounter() {
        _leftCounter++;
    }

    public static String getLeftPlayerKey() {
        return _leftPlayerKey;
    }

    public static String getRightPlayerKey() {
        return _rightPlayerKey;
    }
}
