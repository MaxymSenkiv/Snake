using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlaySnake2D()
    {
        SceneManager.LoadScene("Snake2D");
    }
    public void PlaySnake3D()
    {
        SceneManager.LoadScene("Snake3D");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
