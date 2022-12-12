using UnityEngine;

public class plant_projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool hit;
    private float direction;

    private BoxCollider2D boxCollider;
    private Animator anim;
    private float lifeTime;

    private void Awake() {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(movementspeed,0,0);

        lifeTime += Time.deltaTime;
        if(lifeTime > 4) gameObject.SetActive(false);

    }
    public void shoot()
    {
        lifeTime=0;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
        hit = true;
        boxCollider.enabled = false;
        collision.GetComponent<health>().TakeDamage(damage);
        print(collision.GetComponent<health>().currentHealth);
        Deactivate();
        }
        if(collision.IsTouchingLayers(3))
        {
        hit = true;
        boxCollider.enabled = false;
        Deactivate();
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
