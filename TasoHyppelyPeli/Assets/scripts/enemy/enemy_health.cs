using UnityEngine;

public class enemy_health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    private Animator anim;
    private bool dead;
    private void Awake() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage , 0 , startingHealth);

        if(currentHealth > 0)
        {  
            anim.SetTrigger("hit");
        }
        else
        {
            if(!dead)
            {
            anim.SetTrigger("die");
            GetComponent<slime_movement>().enabled = false;
            dead = true;
            }
        }
    }
    public bool isDead()
    {
        return dead;
    }
}
