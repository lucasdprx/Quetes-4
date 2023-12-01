using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsWindow;
    public void StartGame()
    {
        ShootPlayer.isShootIA = false;
        ShootPlayer.isShootPlayer = false;
        ShootPlayer.turnPlayer = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
