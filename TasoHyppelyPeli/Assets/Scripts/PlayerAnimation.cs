using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;  
    private SpriteRenderer sprite;
    private enum MovementState {idle, running, jumping, falling, attacking};
    private Rigidbody2D rb;

    private float dirX = 0;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        } else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        } else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            state = MovementState.attacking;
        }

        anim.SetInteger("state", (int)state);

    }
}
