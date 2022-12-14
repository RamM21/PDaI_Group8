using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom_movement : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float speed;
    [SerializeField] private float scale = 1.0f;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private Animator anim;
    private Rigidbody2D rb;

    private void Start() 
    {
        leftEdge = transform.position.x - moveDistance;
        rightEdge = transform.position.x + moveDistance;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Update() 
    {
        if(movingLeft)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y);
            }
            else
            movingLeft = false;
        }
        else
        {
            transform.localScale = new Vector3(-scale,scale,scale);
            if(transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y);
            }
            else
            movingLeft = true;
        }
    }
}
