using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public Color gridColor;
    public float gridSize = 1f;
    public int fieldColumns = 20;
    public int fieldRows = 11;
    public float objectSizeFactor = 0.7f;
    public float speed = 2f;

    public GameObject snakePrefab;
    public GameObject foodPrefab;

    private void Start()
    {
        CreateSnake();
        CreateFood();
    }

    public void CreateSnake()
    {
        GameObject snake = Instantiate(snakePrefab);
        snake.name = "Snake";
    }

    public void CreateFood()
    {
        GameObject food = Instantiate(foodPrefab, GetPositionByCoordinates(GetRandomCoordinates()), Quaternion.identity);
        food.name = "Food";
    }

    public Vector2Int GetRandomCoordinates()
    {
        return new Vector2Int(Random.Range(0, fieldColumns), Random.Range(0, fieldRows));
    }

    public Vector3 GetPositionByCoordinates(Vector2Int coordinates)
    {
        return new Vector3(coordinates.x * gridSize + gridSize / 2, coordinates.y * gridSize + gridSize / 2);
    }

    public Vector2Int GetCoordinatesByPosition(Vector3 position)
    {
        return new Vector2Int(
            Mathf.RoundToInt((position.x - gridSize / 2) / gridSize),
            Mathf.RoundToInt((position.y - gridSize / 2) / gridSize)
        );
    }

    public bool IsCoordinatesOutside(Vector2Int coordinates)
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
