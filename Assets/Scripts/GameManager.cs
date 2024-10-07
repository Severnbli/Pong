using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static string _leftPlayerKey = "left shift";
    [SerializeField] private static string _rightPlayerKey = "enter";

    public static string getLeftPlayerKey() {
        return _leftPlayerKey;
    }

    public static string getRightPlayerKey() {
        return _rightPlayerKey;
    }

    public static void setLeftPlayerKey(string key) {
        _leftPlayerKey = key;
    }

    public static void setRightPlayerKey(string key) {
        _rightPlayerKey = key;
    }
}
