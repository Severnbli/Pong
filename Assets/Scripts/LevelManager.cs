using System;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private int _quantityOfHealth = 3;
    private static int _leftPlayerActualCounter = 0;
    private static int _rightPlayerActualCounter = 0;

    void Update()
    {
        _scoreText.text = _leftPlayerActualCounter + ":" + _rightPlayerActualCounter;

        if (Math.Max(_leftPlayerActualCounter, _rightPlayerActualCounter) >= _quantityOfHealth) {
            _leftPlayerActualCounter = _rightPlayerActualCounter = 0;
        }
    }

    public static void incrementLeftCounter() {
        _leftPlayerActualCounter += 1;
    }

    public static void incrementRightCounter() {
        _rightPlayerActualCounter += 1;
    }
}
