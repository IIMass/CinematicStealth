using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}