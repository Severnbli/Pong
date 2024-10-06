using UnityEngine;

public class ButtonsActivity : MonoBehaviour
{
    [SerializeField] private AudioSource _enterSound;
    [SerializeField] private AudioSource _pressedSound;

    public void EnterSound()
    {
        _enterSound.Play();
    }

    public void ClickSound()
    {
        _pressedSound.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
