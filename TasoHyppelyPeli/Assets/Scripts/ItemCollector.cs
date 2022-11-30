using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0;
    private float playerDamage;
    PlayerCombat playerCombat;

    [SerializeField] private Text melonsText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] GameObject player;
    [SerializeField] private float duration;
    [SerializeField] private float damageMultiplier;

    private void Awake()
    {
        playerCombat = player.GetComponent<PlayerCombat> ();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {   
            collectionSoundEffect.Play ();
            Destroy(collision.gameObject);
            melons++;
            melonsText.text = "melons:" + melons;
        }

        if(collision.gameObject.CompareTag("2x"))
        {
            StartCoroutine(Pickup(collision, player));
            Debug.Log("test");
        }
    }

    IEnumerator Pickup(Collider2D damage, GameObject player) 
    {  
        playerCombat.doubleDamage(damageMultiplier);
        damage.GetComponent<SpriteRenderer>().enabled = false;
        damage.GetComponent<BoxCollider2D>().enabled = false;
        player.transform.localScale *= 1.2f;

        yield return new WaitForSeconds(duration);

        playerCombat.doubleDamage(1 / damageMultiplier);
        player.transform.localScale /= 1.2f;
        Destroy(damage.gameObject);
    }
}
