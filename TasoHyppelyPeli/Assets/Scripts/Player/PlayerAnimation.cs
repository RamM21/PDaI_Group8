using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private enum AnimationState { idle, running, jumping, falling, attacking };
    private Rigidbody2D rb;

    private float dirX = 0;
    private Vector3 scale;
    private float scaleX;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        scale = transform.localScale;
        if (scaleX != Mathf.Abs(scale.x))
        {
            scaleX = Mathf.Abs(scale.x);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        AnimationState state;

        if (dirX > 0f && rb.bodyType != RigidbodyType2D.Static) 
        {
            state = AnimationState.running;
            transform.localScale = new Vector3(scaleX, scale.y, scale.z);
        }
        else if (dirX < 0f && rb.bodyType != RigidbodyType2D.Static)
        {
            state = AnimationState.running;
            transform.localScale = new Vector3(-scaleX, scale.y, scale.z);
        }
        else
        {
            state = AnimationState.idle;
        }

        if (rb.velocity.y > .1f && !GetComponent<PlayerMovement>().IsGrounded())
        {
            state = AnimationState.jumping;
        }
        else if (rb.velocity.y < -.1f && !GetComponent<PlayerMovement>().IsGrounded())
        {
            state = AnimationState.falling;
        }

        if (Input.GetButtonDown("Fire1") && rb.bodyType != RigidbodyType2D.Static)
        {
            state = AnimationState.attacking;
        }

        anim.SetInteger("state", (int)state);
    }
}
