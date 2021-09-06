using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private GridScript grid;
    public GameObject foodPrefab;

    private Vector2Int coordinates;
    public Vector2Int Coordinates { get; set; }

    private void Start()
    {
        grid = GameObject.FindWithTag("Grid").GetComponent<GridScript>();

        coordinates = grid.getRandomCoordinates();

        calcScaleAndPosition();
    }

    private void Update()
    {
        calcScaleAndPosition();
    }

    private void calcScaleAndPosition()
    {
        gameObject.transform.localScale = new Vector3(grid.gridSize * grid.objectSizeFactor, grid.gridSize * grid.objectSizeFactor);
        gameObject.transform.position = grid.getPositionByCoordinates(coordinates);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        grid.createFood();
    }
}
