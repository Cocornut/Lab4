using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedGameController : MonoBehaviour
{
    int[,] m_Grid;

    public GameObject GameArea;
    public Rigidbody Asteroid;

    public Vector3 GameAreaSize;
    public Vector3 AsteroidSize;

    public int gridWidth;
    public int gridHeight;
    public float fillPercent = 0.5f;


    void Start()
    {
        SpawnAsteroids();
    }


    void InitialiseGrid()
    {
        GameAreaSize = GameArea.GetComponent<Renderer>().bounds.size;
        AsteroidSize = Asteroid.GetComponent<Collider>().bounds.size;

        gridWidth = Mathf.FloorToInt((GameAreaSize.x / AsteroidSize.x));
        gridHeight = Mathf.FloorToInt((GameAreaSize.z / AsteroidSize.z)) / 2;
        m_Grid = new int[gridWidth, gridHeight];
    }

    void FillGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                m_Grid[x, y] = Random.value > fillPercent ? 0 : 1;
                Debug.Log(m_Grid[x, y]);
            }
        }
    }

    void SpawnAsteroids()
    {
        InitialiseGrid();
        FillGrid();
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 pos = new Vector3(-GameAreaSize.x/2+1 + (AsteroidSize.x * x), 0, GameAreaSize.z/2 - (AsteroidSize.z * y));
                if (m_Grid[x,y] == 1)
                {
                    Instantiate(Asteroid, pos, transform.rotation);
                }

            }
        }
    }
}
