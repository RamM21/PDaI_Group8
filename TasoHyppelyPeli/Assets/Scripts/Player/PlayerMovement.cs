using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float moveForce = 11f;
    [SerializeField] private float lowJumpMultiplier = 10f;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource stepSound;
    [SerializeField] private AudioSource landSound;

    public GameObject fallDetector; 

    public static Vector2 lastCheckpointPos = new Vector2(-6, 1);
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
    }
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveForce, rb.velocity.y);
        if (rb.velocity.x != 0 && IsGrounded() && !stepSound.isPlaying)
        {
            stepSound.Play();
        }
       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
        }

        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
           rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime; 
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            landSound.Play();
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = lastCheckpointPos;
        }
    }
}
