using UnityEngine;
using System.Collections;

public class enemy_health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    [Header("sounds")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    private Animator anim;
    private AudioSource source;
    private bool dead = false;
    private void Awake() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage , 0 , startingHealth);

        if(currentHealth > 0)
        {  
            anim.SetTrigger("hit");
            source.PlayOneShot(hurtSound);
        }
        else
        {
            if(!dead)
            {
            anim.SetTrigger("die");
            source.loop=false;
            source.PlayOneShot(deathSound);

            if(GetComponent<bunny_movement>() != null)
                GetComponent<bunny_movement>().enabled=false;
            if(GetComponent<chameleon_movement>() != null)
            {
                GetComponent<chameleon_movement>().StopAllCoroutines();
                GetComponent<chameleon_movement>().enabled=false;
            }
            if(GetComponent<chameleon_attack>() != null)
            {
                GetComponent<chameleon_attack>().StopAllCoroutines();
                GetComponent<chameleon_attack>().enabled=false;
            }
            if(GetComponent<duck_movement>() != null)
            {
                GetComponent<duck_movement>().StopAllCoroutines();
                GetComponent<duck_movement>().enabled=false;
            }
            if(GetComponent<slime_movement>() != null)
                GetComponent<slime_movement>().enabled=false;
            if(GetComponent<plant_attack>() != null)
                GetComponent<plant_attack>().enabled=false;
            if(GetComponent<enemy_damage>() != null)
                GetComponent<enemy_damage>().enabled=false;
            if(GetComponent<Rigidbody2D>() != null)
                GetComponent<Rigidbody2D>().simulated=false;
            if(GetComponent<BoxCollider2D>() != null)
                GetComponent<BoxCollider2D>().enabled=false;
            if(GetComponent<SpriteRenderer>().sortingLayerName == "foreground")
                GetComponent<SpriteRenderer>().sortingLayerName = "background";
            StartCoroutine(delete());
            
            dead = true;
            }
        }
    }
    public bool isDead()
    {
        return dead;
    }
    private IEnumerator delete()
    {
        yield return new WaitForSeconds((float)1.8);
        if(GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().enabled=false;
        
        gameObject.SetActive(false);
    }
}
