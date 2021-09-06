using UnityEngine;

enum Direction
{
    UP, RIGHT, DOWN, LEFT
}

public class SnakeScript : MonoBehaviour
{
    private GridScript grid;

    private Vector2Int coordinates;
    public Vector2Int Coordinates { get; set; }

    private Direction direction;

    void Start()
    {
        grid = GameObject.FindWithTag("Grid").GetComponent<GridScript>();

        coordinates = grid.getRandomCoordinates();
        direction = (Direction)Random.Range(0, System.Enum.GetNames(typeof(Direction)).Length);

        gameObject.transform.localScale = calcScale();
        gameObject.transform.position = grid.getPositionByCoordinates(coordinates);

        InvokeRepeating("Move", 1f, grid.speed);
    }

    void Update()
    {
        if (grid.isCoordinatesOutside(coordinates))
        {
            Destroy(gameObject);
            grid.createSnake();
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.UP;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.LEFT;
        }

        gameObject.transform.localScale = calcScale();
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, grid.getPositionByCoordinates(coordinates), 0.03f);

        //Move();
    }

    private Vector3 calcScale()
    {
        return new Vector3(grid.gridSize * grid.objectSizeFactor, grid.gridSize * grid.objectSizeFactor);
    }

    private void Move()
    {
        switch (direction)
        {
            case Direction.UP:
                coordinates += Vector2Int.up;
                break;
            case Direction.RIGHT:
                coordinates += Vector2Int.right;
                break;
            case Direction.DOWN:
                coordinates += Vector2Int.down;
                break;
            case Direction.LEFT:
                coordinates += Vector2Int.left;
                break;
        }
    }
}
