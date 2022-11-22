using UnityEngine;
using System.Collections;

public class firetrap : MonoBehaviour
{
    [SerializeField]private float damage;
    [Header("Sounds")]
    [SerializeField]private AudioClip fireSound;
    [SerializeField]private AudioClip activationSound;
    [Header("Firetrap Timers")]
    [SerializeField]private float activationDelay;
    [SerializeField]private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool load;
    private bool triggered;
    private bool active;
    private health player;
    private AudioSource source;

    private void Awake() {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        load=true;
    }
    
    private void Update() {
        if(active && player != null && load)
        {
            player.TakeDamage(damage);
            load=false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(ActivateFiretrap());
                player = collision.GetComponent<health>();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        player=null;
    }
    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;
        source.PlayOneShot(activationSound);

        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated",true);
        source.PlayOneShot(fireSound);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        load=true;
        anim.SetBool("activated",false);
    }
}
