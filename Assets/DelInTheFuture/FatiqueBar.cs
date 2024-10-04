using UnityEngine;
using UnityEngine.UI;

public class FatiqueBar : MonoBehaviour
{
    [SerializeField] private float _staminaAmount = 100.0f;
    [SerializeField] private float _fatiqueAmount = 1.0f;
    private float _nowFatigueAmount = 0;
    private Image _barImage;

    void Start()
    {
        _barImage = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(GameManager.getLeftPlayerKey())) {
            if (_nowFatigueAmount < _staminaAmount) {
                _nowFatigueAmount += _fatiqueAmount;
            }
        } else {
            if (_nowFatigueAmount > 0) {
                _nowFatigueAmount -= _fatiqueAmount;
            }
        }

        _nowFatigueAmount = Mathf.Clamp(_nowFatigueAmount, 0, _staminaAmount);

        if (_nowFatigueAmount > 0) {
            _barImage.fillAmount = (_staminaAmount - _nowFatigueAmount) / _staminaAmount;
        } else {
            _barImage.fillAmount = 1;
        }
    }
}
