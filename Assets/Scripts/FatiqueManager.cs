using UnityEngine;

public class FatiqueManager : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _flickerMaterial;

    [SerializeField] private int _staminaAmount = 4;
    [SerializeField] private int _fatiqueAmount = 1;

    public Material DefaultMaterial
    {
        get { return _defaultMaterial; }
    }

    public Material FlickerMaterial
    {
        get { return _flickerMaterial; }
    }

    public int StaminaAmount
    {
        get { return _staminaAmount; }
    }

    public int FatiqueAmount
    {
        get { return _fatiqueAmount; }
    }
}