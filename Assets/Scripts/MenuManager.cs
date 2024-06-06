using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Activate game over screen
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Activate Game
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    //Activate Credits
    public void Credit()
    {
        SceneManager.LoadScene(1);
    }
    //Activate End Credits
    public void End()
    {
        SceneManager.LoadScene(4);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)
    }
}