using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunny_movement : MonoBehaviour
{
    private Animator anim;

    private float leftBoundary;
    private float rightBoundary;
    private Direction direction;

    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float scale = 1.0f;

    private void Awake()
    {
        SetBoundaries();
        anim = GetComponent<Animator>();
        direction = Direction.Left;
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (direction == Direction.Left)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            if (transform.position.x > leftBoundary)
            {
                MoveLeft();
            }
            else
            {
                direction = Direction.Right;
            }
        }
        else
        {
            transform.localScale = new Vector3(-scale, scale, scale);
            if (transform.position.x < rightBoundary)
            {
                MoveRight();
            }
            else
            {
                direction = Direction.Left;
            }
        }
    }

    private void SetBoundaries()
    {
        leftBoundary = transform.position.x - distance;
        rightBoundary = transform.position.x + distance;
    }

    private void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private enum Direction
    {
        Left,
        Right
    }
}
