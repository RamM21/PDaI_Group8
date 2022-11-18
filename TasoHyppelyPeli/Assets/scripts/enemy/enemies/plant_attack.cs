using UnityEngine;

public class plant_attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject[] bullet;

    private float coolDownTimer = Mathf.Infinity;
    private Animator anim;
    private health player;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if(coolDownTimer > attackCooldown)
        {
            print("attacked");
            Attack();
        }
        coolDownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
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
