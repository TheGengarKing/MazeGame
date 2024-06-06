using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public int wallPoolSize = 10;
    public int floorPoolSize = 100;

    private List<GameObject> wallPool;
    private List<GameObject> floorPool;

    void Start()
    {
        InitializePools();
    }

    void InitializePools()
    {
        wallPool = new List<GameObject>();
        floorPool = new List<GameObject>();

        for (int i = 0; i < wallPoolSize; i++)
        {
            GameObject wall = Instantiate(wallPrefab, transform);
            wall.SetActive(false);
            wallPool.Add(wall);
        }

        for (int i = 0; i < floorPoolSize; i++)
        {
            GameObject floor = Instantiate(floorPrefab, transform);
            floor.SetActive(false);
            floorPool.Add(floor);
        }
    }

    public GameObject GetWall()
    {
        foreach (GameObject wall in wallPool)
        {
            if (!wall.activeInHierarchy)
            {
                wall.SetActive(true);
                return wall;
            }
        }

        GameObject newWall = Instantiate(wallPrefab, transform);
        newWall.SetActive(true);
        wallPool.Add(newWall);
        return newWall;
    }

    public GameObject GetFloor()
    {
        foreach (GameObject floor in floorPool)
        {
            if (!floor.activeInHierarchy)
            {
                floor.SetActive(true);
                return floor;
            }
        }

        GameObject newFloor = Instantiate(floorPrefab, transform);
        newFloor.SetActive(true);
        floorPool.Add(newFloor);
        return newFloor;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
