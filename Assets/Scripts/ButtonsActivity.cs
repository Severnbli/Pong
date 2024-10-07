using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1() {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2() {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3() {
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4() {
        SceneManager.LoadScene("Level4");
    }

    public void RunEverything() {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
