using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    UP, RIGHT, DOWN, LEFT
}

public class SnakeScript : MonoBehaviour
{
    public GameObject snakeBlockPrefab;
    private GridScript grid;

    private List<SnakeBlockScript> body = new List<SnakeBlockScript>();
    private Direction direction;

    void Start()
    {
        grid = GameObject.FindWithTag("Grid").GetComponent<GridScript>();

        Vector3 position = grid.GetPositionByCoordinates(grid.GetRandomCoordinates());
        body.Add(CreateSnakeBlock(position));

        direction = (Direction)Random.Range(0, System.Enum.GetNames(typeof(Direction)).Length);

        InvokeRepeating("Move", 1f, 1 / grid.speed);
    }

    private SnakeBlockScript CreateSnakeBlock(Vector3 position)
    {
        SnakeBlockScript block = Instantiate(snakeBlockPrefab, position, Quaternion.identity, transform).GetComponent<SnakeBlockScript>();
        block.name = "Block " + body.Count;
        return block;
    }

    private void Move()
    {
        Vector2Int prevCoordinatesFirst = body[0].Coordinates;
        switch (direction)
        {
            case Direction.UP:
                body[0].Coordinates += Vector2Int.up;
                break;
            case Direction.RIGHT:
                body[0].Coordinates += Vector2Int.right;
                break;
            case Direction.DOWN:
                body[0].Coordinates += Vector2Int.down;
                break;
            case Direction.LEFT:
                body[0].Coordinates += Vector2Int.left;
                break;
        }

        for (int i = 1; i < body.Count; i++)
        {
            Vector2Int prevCoordinatesSecond = body[i].Coordinates;
            body[i].Coordinates = prevCoordinatesFirst;
            prevCoordinatesFirst = prevCoordinatesSecond;
        }
    }

    void Update()
    {
        if (grid.IsCoordinatesOutside(body[0].Coordinates))
        {
            Destroy(gameObject);
            grid.CreateSnake();
            return;
        }

        ProcessInput();
    }

    private void ProcessInput()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Vector2Int oppositeDirectionVector = new Vector2Int();
            switch (direction)
            {
                case Direction.UP:
                    oppositeDirectionVector = Vector2Int.down;
                    break;
                case Direction.RIGHT:
                    oppositeDirectionVector = Vector2Int.left;
                    break;
                case Direction.DOWN:
                    oppositeDirectionVector = Vector2Int.up;
                    break;
                case Direction.LEFT:
                    oppositeDirectionVector = Vector2Int.right;
                    break;
            }

            Vector2Int tailCoordinates = body[body.Count - 1].Coordinates;
            Vector3 position = grid.GetPositionByCoordinates(tailCoordinates + oppositeDirectionVector);
            body.Add(CreateSnakeBlock(position));
        }
    }
}
