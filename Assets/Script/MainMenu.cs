using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public GameObject settingsWindow;
    public void StartGame()
    {
        ShootPlayer.isShootIA = false;
        ShootPlayer.isShootPlayer = false;
        ShootPlayer.turnPlayer = true;
        Time.timeScale = 1.0f;
        audioSource.PlayOneShot(sound);
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        audioSource.PlayOneShot(sound);
    }
    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        audioSource.PlayOneShot(sound);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
