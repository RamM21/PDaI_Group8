using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunny_movement : MonoBehaviour
{
    private Animator anim;

    private float leftDistance;
    private float rightDistange;
    private bool direction;

    private Vector3 scale;
    private float scaleX;

    [SerializeField] private float speed;
    [SerializeField] private float distance;
    
    private void Awake()
    {
        leftDistance = transform.position.x - distance;
        rightDistange = transform.position.x + distance;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Scale();
        movement();
    }

    private void movement()
    {
        if(direction)
        {
            transform.localScale = new Vector3(scaleX,scale.y,scale.z);
            if(transform.position.x > leftDistance)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            direction = false;
        }
        else
        {
            transform.localScale = new Vector3(-scaleX,scale.y,scale.z);
            if(transform.position.x < rightDistange)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            direction = true;
        }
    }

    private void Scale()
    {
        scale = transform.localScale;
        if (scaleX != Mathf.Abs(scale.x))
        {
            scaleX = Mathf.Abs(scale.x);
        }
    }
}
