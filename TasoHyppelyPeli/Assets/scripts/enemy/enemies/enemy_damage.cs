using UnityEngine;

public class enemy_damage : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool dead;

    private void OnTriggerEnter2D(Collider2D collision) {
        dead = GetComponent<enemy_health>().isDead();
        if(collision.tag == "Player" && !dead)
        {
            collision.GetComponent<health>().TakeDamage(damage);
        }
    }
}
