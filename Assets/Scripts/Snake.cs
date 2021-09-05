using UnityEngine;

enum Direction
{
    UP, RIGHT, DOWN, LEFT
}

public class Snake : MonoBehaviour
{
    private Direction direction = Direction.UP;

    void Start()
    {
        InvokeRepeating("Move", 0.5f, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Direction.UP;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = Direction.RIGHT;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            direction = Direction.DOWN;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            direction = Direction.LEFT;
        }
    }

    void Move()
    {
        var currentTransform = gameObject.transform;
        float dx = currentTransform.position.x;
        float dy = currentTransform.position.y;
        switch (direction)
        {
            case Direction.UP:
                dy += currentTransform.localScale.y;
                break;
            case Direction.RIGHT:
                dx += currentTransform.localScale.x;
                break;
            case Direction.DOWN:
                dy -= currentTransform.localScale.y;
                break;
            case Direction.LEFT:
                dx -= currentTransform.localScale.x;
                break;
        }
        gameObject.transform.position = new Vector3(dx, dy);
    }
}
