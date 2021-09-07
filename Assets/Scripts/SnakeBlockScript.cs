using UnityEngine;

public class SnakeBlockScript : MonoBehaviour
{
    private GridScript grid;

    private Vector2Int coordinates;

    public Vector2Int Coordinates { get => coordinates; set => coordinates = value; }

    void Start()
    {
        grid = GameObject.FindWithTag("Grid").GetComponent<GridScript>();

        coordinates = grid.GetCoordinatesByPosition(transform.position);

        transform.localScale = CalcScale();
    }

    void Update()
    {
        transform.localScale = CalcScale();
        transform.position = Vector3.Lerp(transform.position, grid.GetPositionByCoordinates(coordinates), 0.03f);
        //transform.position = grid.GetPositionByCoordinates(coordinates);
    }

    private Vector3 CalcScale()
    {
        return new Vector3(grid.gridSize * grid.objectSizeFactor, grid.gridSize * grid.objectSizeFactor);
    }
}
