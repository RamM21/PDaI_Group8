using UnityEngine;

public class enemy_vertical : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    [Header("Sounds")]
    [SerializeField] private AudioClip activeSound;
    [SerializeField] private AudioClip hitSound;
    private AudioSource source;
    private bool movingUp;
    private float upEdge;
    private float downEdge;


    private void Awake() {
        upEdge = transform.position.y + movementDistance;
        downEdge = transform.position.y - movementDistance;
        source = GetComponent<AudioSource>();
        source.clip=activeSound;
        source.loop=true;
        source.Play();
    }
    private void Update() {
        if(movingUp)
        {
            if(transform.position.y < upEdge)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + speed * Time.deltaTime,transform.position.z);
            }
            else
            movingUp = false;
        }
        else
        {
            if(transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y - speed * Time.deltaTime,transform.position.z);
            }
            else
            movingUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            source.PlayOneShot(hitSound);
            collision.GetComponent<health>().TakeDamage(damage);
        }
    }
}
