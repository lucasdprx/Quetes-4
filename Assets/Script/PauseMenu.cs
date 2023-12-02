using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public AudioSource audioSource;
    public AudioClip sound;

    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        audioSource.PlayOneShot(sound);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        audioSource.PlayOneShot(sound);
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        audioSource.PlayOneShot(sound);
        Resume();
    }

}
