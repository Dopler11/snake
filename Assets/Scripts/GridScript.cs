using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject foodPrefab;
    public Color gridColor;
    public float gridSize = 1f;
    public int fieldColumns = 20;
    public int fieldRows = 11;
    public float objectSizeFactor = 0.7f;
    public float speed = 0.5f;

    private void Start()
    {
        createSnake();
        createFood();
    }

    public void createSnake()
    {
        GameObject snake = Instantiate(snakePrefab, getPositionByCoordinates(getRandomCoordinates()), Quaternion.identity);
        snake.name = "Snake";
    }

    public void createFood()
    {
        GameObject food = Instantiate(foodPrefab, getPositionByCoordinates(getRandomCoordinates()), Quaternion.identity);
        food.name = "Food";
    }

    public Vector2Int getRandomCoordinates()
    {
        int column = Random.Range(0, fieldColumns);
        int row = Random.Range(0, fieldRows);
        return new Vector2Int(column, row);
    }

    public Vector3 getPositionByCoordinates(Vector2Int coordinates)
    {
        return new Vector3(coordinates.x * gridSize + gridSize / 2, coordinates.y * gridSize + gridSize / 2);
    }

    public bool isCoordinatesOutside(Vector2Int coordinates)
    {
        return coordinates.x < 0 || coordinates.x > fieldColumns - 1 || coordinates.y < 0 || coordinates.y > fieldRows - 1;
    }

    void OnDrawGizmos()
    {
        float fieldWidht = fieldColumns * gridSize;
        float fieldHeight = fieldRows * gridSize;

        Gizmos.color = gridColor;
        for (int i = 0; i <= fieldColumns; i++)
        {
            Gizmos.DrawLine(new Vector3(i * gridSize, 0), new Vector3(i * gridSize, fieldHeight));
            for (int j = 0; j <= fieldRows; j++)
            {
                Gizmos.DrawLine(new Vector3(0, j * gridSize), new Vector3(fieldWidht, j * gridSize));
            }
        }
    }
}
