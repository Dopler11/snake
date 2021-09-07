using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private GridScript grid;
    public GameObject foodPrefab;

    private Vector2Int coordinates;

    private void Start()
    {
        grid = GameObject.FindWithTag("Grid").GetComponent<GridScript>();

        coordinates = grid.GetRandomCoordinates();

        calcScaleAndPosition();
    }

    private void Update()
    {
        calcScaleAndPosition();
    }

    private void calcScaleAndPosition()
    {
        gameObject.transform.localScale = new Vector3(grid.gridSize * grid.objectSizeFactor, grid.gridSize * grid.objectSizeFactor);
        gameObject.transform.position = grid.GetPositionByCoordinates(coordinates);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        grid.CreateFood();
    }
}
