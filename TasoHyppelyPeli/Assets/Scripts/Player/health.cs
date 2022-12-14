using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    private Animator anim;
    private bool dead;
    private Vector3 respawnPoint;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private AudioSource damageSound;
	
	private SpriteRenderer spriteRend;
    private Rigidbody2D rb;

    public HealthBar healthBar;

    private void Awake() {
        gameOver.setLevel(SceneManager.GetActiveScene().buildIndex);
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(startingHealth);
    }

    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage , 0 , startingHealth);
        damageSound.Play();
        if(currentHealth > 0)
        {  
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
            anim.SetTrigger("death");
            dead = true;
            gameObject.GetComponent<PlayerCombat>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<PlayerAnimation>().enabled = false;
            gameOver.setScore(GetComponent<ItemCollector>().getMelonCount());
            Invoke("gameOverScene",(float)1.5);
            }
        }
        healthBar.SetHealth(currentHealth);
    }
    public void addHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value,0,startingHealth);
        healthBar.SetHealth(currentHealth);
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8 ,9 ,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(8 ,9 ,false);
    }
    private void gameOverScene()
    {
        SceneManager.LoadScene("gameOver");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}