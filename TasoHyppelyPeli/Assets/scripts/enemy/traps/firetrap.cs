using UnityEngine;
using System.Collections;

public class firetrap : MonoBehaviour
{
    [SerializeField]private float damage;
    [Header("Firetrap Timers")]
    [SerializeField]private float activationDelay;
    [SerializeField]private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool load;
    private bool triggered;
    private bool active;
    private health player;

    private void Awake() {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
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

        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated",true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        load=true;
        anim.SetBool("activated",false);
    }
}
