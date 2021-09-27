using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;

    [SerializeField] private GameObject _pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }    
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        Paused = true;
        _pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Paused = false;
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
