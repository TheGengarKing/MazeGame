using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width, height;
    public GameObject wallPrefab, floorPrefab, goalPrefab;
    public GameObject playerPrefab;
    public int[,] maze;
    public Vector2Int startPosition;
    public Vector2Int goalPosition;
    public float scaleFactor = 0.5f; // Assuming 50x50 pixels and 100 pixels per unit
    private Stack<Vector2Int> backtrackStack = new Stack<Vector2Int>(); // Declare backtrack stack

    private void Start()
    {
        GenerateMaze();
        PlacePlayer();
        PlaceGoalRandom();
    }

    public void GenerateMaze() // Created by AI, edited by me (to fix errors and such) 
    {
        maze = new int[width * 2 + 1, height * 2 + 1];

        // Initialize maze with walls
        for (int x = 0; x < width * 2 + 1; x++)
        {
            for (int y = 0; y < height * 2 + 1; y++)
            {
                maze[x, y] = 1; // Set walls
            }
        }

        startPosition = new Vector2Int(1, 1); // Start position
        goalPosition = new Vector2Int(width * 2 - 1, height * 2 - 1); // Goal position
        maze[startPosition.x, startPosition.y] = 0; // Clear starting position

        GeneratePaths(startPosition); // Generate paths from the start position
    }

    private void GeneratePaths(Vector2Int position) // Created by AI, edited by me (to fix errors and such)
    {
        List<Vector2Int> unvisitedNeighbors = GetUnvisitedNeighbors(position);
        while (unvisitedNeighbors.Count > 0)
        {
            Vector2Int selectedNeighbor = unvisitedNeighbors[Random.Range(0, unvisitedNeighbors.Count)];
            Vector2Int wallPosition = (position + selectedNeighbor) / 2;
            maze[wallPosition.x, wallPosition.y] = 0; // Clear path
            maze[selectedNeighbor.x, selectedNeighbor.y] = 0; // Clear selected neighbor
            backtrackStack.Push(position); // Push current position to the backtrack stack
            GeneratePaths(selectedNeighbor); // Recursively generate paths from the selected neighbor
            unvisitedNeighbors = GetUnvisitedNeighbors(position);
        }
        if (backtrackStack.Count > 0)
        {
            GeneratePaths(backtrackStack.Pop()); // Backtrack and continue generating paths
        }
    }

    private List<Vector2Int> GetUnvisitedNeighbors(Vector2Int position) // Created by AI, edited by me (to fix errors and such)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        if (position.x > 2 && maze[position.x - 2, position.y] == 1) neighbors.Add(new Vector2Int(position.x - 2, position.y));
        if (position.x < width * 2 - 2 && maze[position.x + 2, position.y] == 1) neighbors.Add(new Vector2Int(position.x + 2, position.y));
        if (position.y > 2 && maze[position.x, position.y - 2] == 1) neighbors.Add(new Vector2Int(position.x, position.y - 2));
        if (position.y < height * 2 - 2 && maze[position.x, position.y + 2] == 1) neighbors.Add(new Vector2Int(position.x, position.y + 2));

        return neighbors;
    }

    public void PlacePlayer()
    {
        Vector3 playerPos = new Vector3(startPosition.x * scaleFactor, startPosition.y * scaleFactor, 0);
        Instantiate(playerPrefab, playerPos, Quaternion.identity);
    }

    private void PlaceGoalRandom()
    {
        // Initialize variables
        int randomX, randomY;
        bool validPosition = false;

        // Repeat until a valid position is found
        while (!validPosition)
        {
            // Generate random coordinates within maze bounds
            randomX = Random.Range(1, width * 2);
            randomY = Random.Range(1, height * 2);

            // Check if the position is not on a wall
            if (maze[randomX, randomY] == 0)
            {
                // Set the goal position
                goalPosition = new Vector2Int(randomX, randomY);
                validPosition = true;
            }
        }

        // Place the goal at the selected position
        Vector3 goalPos = new Vector3(goalPosition.x * scaleFactor, goalPosition.y * scaleFactor, 0);
        Instantiate(goalPrefab, goalPos, Quaternion.identity);
    }

    public void DrawMaze() // Created by AI, edited by me (to fix errors and such)
    {
        for (int x = 0; x < width * 2 + 1; x++)
        {
            for (int y = 0; y < height * 2 + 1; y++)
            {
                Vector3 pos = new Vector3(x * scaleFactor, y * scaleFactor, 0);
                if (maze[x, y] == 1)
                {
                    Instantiate(wallPrefab, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(floorPrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}
