using UnityEngine;

public class trap_damage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private AudioClip clip;
    private AudioSource source;

    private void Awake() {
        source=GetComponent<AudioSource>();
    }
    protected void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            source.PlayOneShot(clip);
            collision.GetComponent<health>().TakeDamage(damage);
        }
    }
}
