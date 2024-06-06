using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public MazeGenerator mazeGenerator;

    void Start()
    {
        // Set level parameters based on the current level
        SetLevelParameters();

        // Generate and draw the maze
        mazeGenerator.GenerateMaze();
        mazeGenerator.DrawMaze();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload current level
            SceneManager.LoadScene("Level" + currentLevel);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Quit current level
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            // Quit current level
            SceneManager.LoadScene(0);
        }
    }

    void SetLevelParameters()
    {
        switch (currentLevel)
        {
            case 1:
                mazeGenerator.width = 10;
                mazeGenerator.height = 10;
                break;
            case 2:
                mazeGenerator.width = 20;
                mazeGenerator.height = 20;
                break;
            case 3:
                mazeGenerator.width = 30;
                mazeGenerator.height = 30;
                break;
            default:
                mazeGenerator.width = 10;
                mazeGenerator.height = 10;
                break;
        }
    }

    public void NextLevel()
    {
        if (currentLevel < 3) // If not on the last level
        {
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);
        }
        else // If on the last level, load the end screen
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
