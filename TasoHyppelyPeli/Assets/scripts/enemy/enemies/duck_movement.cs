using UnityEngine;
using System.Collections;
public class duck_movement : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header ("movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float crouchTime;
    [SerializeField] private float changeSideTime;
    private float changeRate;
    private bool crouch;
    private bool dead;
    private float facing;
    private Animator anim;
    private Rigidbody2D body;

    private void Awake() {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        changeRate = changeSideTime;
        facing = transform.localScale.x;
    }

    private void Update() {
        if(body.velocity.y < 0)
        {
            anim.SetBool("jump",false);
            anim.SetBool("fall",true);
        }
        else if(body.velocity.y > 0.5)
        {
            anim.SetBool("jump",true);
            anim.SetBool("fall",false);
        }
        else{
            anim.SetBool("fall",false);
        }
        changeSide();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        dead = GetComponent<enemy_health>().isDead();
        if(collision.collider.tag == "Player" && !dead)
            collision.collider.GetComponent<health>().TakeDamage(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            crouch = true;
            anim.SetBool("crouch",true);
            StartCoroutine(attack());
        }
    }
    private void jump()
    {
        body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x)*speed,jumpPower);
    }
    private void changeSide()
    {
        if(!crouch && body.velocity.y == 0)
            changeRate = changeRate-Time.deltaTime;

        if(changeRate < 0)
        {
            changeRate = changeSideTime;
            transform.localScale = new Vector3(facing*-1,4,4);
            facing = transform.localScale.x;
        }
    }
    private IEnumerator attack()
    {
        yield return new WaitForSeconds(crouchTime);
        crouch = false;
        anim.SetBool("crouch",false);
        jump();
    }
}
