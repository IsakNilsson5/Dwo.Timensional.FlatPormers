using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoryatlast : MonoBehaviour
{
    public void Restartthegame()
    {
        SceneManager.LoadScene(0);
    }
    public void Quitthegame()
    {
        Application.Quit();
    }
}
