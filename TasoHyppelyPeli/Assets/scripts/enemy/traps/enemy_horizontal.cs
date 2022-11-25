using UnityEngine;

public class enemy_horizontal : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    [Header("Sounds")]
    [SerializeField] private AudioClip activeSound;
    [SerializeField] private AudioClip hitSound;
    private AudioSource source;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;


    private void Awake() {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        source = GetComponent<AudioSource>();
        source.clip=activeSound;
        source.loop=true;
        source.Play();
    }
    private void Update() {
        if(movingLeft)
        {
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            movingLeft = false;
        }
        else
        {
            if(transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            movingLeft = true;
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
