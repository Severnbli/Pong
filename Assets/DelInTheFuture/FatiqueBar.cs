using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FatiqueBar : MonoBehaviour
{
    [SerializeField] private int _staminaAmount = 4;
    [SerializeField] private int _fatiqueAmount = 1;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _flickerMaterial;
    private int _nowFatigueAmount = 0;
    private Image _barImage;
    private bool _isPlayAnimation = false;
    private String _keyName;

    void Start()
    {
        _barImage = GetComponent<Image>();
        StartCoroutine(stamina());
        
        if (gameObject.tag == "RightFlipper") {
            _keyName = GameManager.getRightPlayerKey();
        } else if (gameObject.tag == "LeftFlipper") {
            _keyName = GameManager.getLeftPlayerKey();
        }
    }

    void Update()
    {
        if (!_isPlayAnimation) {
            prepareUpdate();
        }

        _barImage.fillAmount = (float) (_staminaAmount - _nowFatigueAmount) / _staminaAmount;
    }

    private void prepareUpdate() {

        if (Input.GetKeyDown(_keyName)) {
            fatique();
        }

        if (_nowFatigueAmount >= _staminaAmount) {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(gameObject.tag);
            
            foreach (GameObject findObject in gameObjects) {
                SpriteRenderer spriteRenderer = findObject.GetComponent<SpriteRenderer>();
                FlipperMovement flipperMovement = findObject.GetComponent<FlipperMovement>();
                
                if (spriteRenderer && flipperMovement) {
                    StartCoroutine(flicker(spriteRenderer, flipperMovement));
                }
            }
        }
    }

    private void fatique() {
        if (_nowFatigueAmount < _staminaAmount) {
                _nowFatigueAmount += _fatiqueAmount;
            }
    }

    private IEnumerator stamina() {
        while (true) {
            yield return new WaitForSeconds(2.0f);
            if (_nowFatigueAmount > 0) {
                _nowFatigueAmount -= _fatiqueAmount;
            }
        }
    }

    private IEnumerator flicker(SpriteRenderer spriteRenderer, FlipperMovement flipperMovement) {
        _isPlayAnimation = true;
        flipperMovement.changeStatus();

        spriteRenderer.material = _flickerMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _defaultMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _flickerMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _defaultMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _flickerMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _defaultMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _flickerMaterial;
        yield return new WaitForSeconds(.8f);
        spriteRenderer.material = _defaultMaterial;

        _isPlayAnimation = false;
        flipperMovement.changeStatus();
    }
}
