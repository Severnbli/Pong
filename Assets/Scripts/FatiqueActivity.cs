using System.Collections;
using UnityEngine;

public class FatiqueActivity : MonoBehaviour
{
    [SerializeField] private GameObject _flipperManager;
    private Material _defaultMaterial;
    private Material _flickerMaterial;

    private int _staminaAmount;
    private int _fatiqueAmount;
    private int _nowFatigueAmount = 0;
    private bool _isPlayAnimation = false;
    private string _keyName;

    void Start()
    {
        StartCoroutine(stamina());
        
        if (gameObject.tag == "RightFlipper") {
            _keyName = GameManager.getRightPlayerKey();
        } else if (gameObject.tag == "LeftFlipper") {
            _keyName = GameManager.getLeftPlayerKey();
        }

        FatiqueManager fatiqueManager = _flipperManager.GetComponent<FatiqueManager>();

        _defaultMaterial = fatiqueManager.DefaultMaterial;
        _flickerMaterial = fatiqueManager.FlickerMaterial;
        _staminaAmount = fatiqueManager.StaminaAmount;
        _fatiqueAmount = fatiqueManager.FatiqueAmount;
    }

    void Update()
    {
        if (!_isPlayAnimation) {
            prepareUpdate();
        }
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
