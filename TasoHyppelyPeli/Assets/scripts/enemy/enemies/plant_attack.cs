using UnityEngine;
using System.Collections;

public class plant_attack : MonoBehaviour
{
    [Header("properties")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject[] bullet;
    [Header("sounds")]
    [SerializeField] private AudioClip shootSound;
    private AudioSource source;

    private float coolDownTimer = Mathf.Infinity;
    private Animator anim;
    private health player;

    private void Awake() {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update() {
        if(coolDownTimer > attackCooldown)
        {
            Attack();
        }
        coolDownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        source.Stop();
        anim.SetTrigger("attack");
        source.PlayOneShot(shootSound);
        coolDownTimer = 0;
        
        bullet[getBullet()].transform.position = shootPoint.position;
        bullet[getBullet()].GetComponent<plant_projectile>().shoot();
    }
    private int getBullet()
    {
        for(int i=0; i < bullet.Length; i++){
            if(!bullet[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
