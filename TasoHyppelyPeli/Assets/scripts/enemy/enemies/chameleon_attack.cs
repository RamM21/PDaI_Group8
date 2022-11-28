using UnityEngine;
using System.Collections;

public class chameleon_attack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;
    [SerializeField] private AudioClip attackSound;
    private AudioSource source;
    private health player;
    private bool load;
    private bool aboutAttack;
    private Animator anim;
    private bool doAttack;
    private chameleon_movement walk;
    
    private void Awake() {
        anim = GetComponent<Animator>();
        walk = GetComponent<chameleon_movement>();
        source = GetComponent<chameleon_movement>().source;
        load=true;
    }
    private void Update() {
        if(doAttack && player!=null && load)
        {
            player.TakeDamage(damage);
            load=false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            if(!aboutAttack){
                player = collision.GetComponent<health>();
                StartCoroutine(attack());
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        player=null;
    }
    private IEnumerator attack()
    {
        walk.enabled=false;
        yield return new WaitForSeconds(attackDelay);
        anim.SetTrigger("attacking");
        source.PlayOneShot(attackSound);
        doAttack=true;
        aboutAttack=true;
        yield return new WaitForSeconds(1);
        doAttack=false;
        aboutAttack=false;
        load=true;
        walk.enabled=true;
    }
}
