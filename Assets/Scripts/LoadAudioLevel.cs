using System.Collections;
using UnityEngine;

public class LoadAudioLevel : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToLoad;

    void Start()
    {
        _gameObjectToLoad.SetActive(true);
        _gameObjectToLoad.SetActive(false);
    }
}
