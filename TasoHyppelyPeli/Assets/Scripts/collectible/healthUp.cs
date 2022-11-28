using UnityEngine;
using System.Collections;
public class healthUp : MonoBehaviour
{
    [SerializeField] private float healingAmount;
    [SerializeField] private AudioClip clip;
    private Animator anim;
    private AudioSource source;

    private void Awake() {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Player")
        {
            collision.GetComponent<health>().addHealth(healingAmount);
            StartCoroutine(pickedUp());
        }
    }

    private IEnumerator pickedUp()
    {
        source.PlayOneShot(clip);
        anim.SetTrigger("collected");
        yield return new WaitForSeconds((float)1.2);
        gameObject.SetActive(false);
    }
}
