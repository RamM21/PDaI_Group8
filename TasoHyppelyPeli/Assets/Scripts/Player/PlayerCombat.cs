using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRangeX = 3.38f;
    [SerializeField] private float attackRangeY = 2.83f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackDamage = 1f;
    
    [SerializeField] private AudioSource attackSound;
    private Rigidbody2D rb;
    private Vector2 attackRangeSize;
    private float attackRate = .25f;
    private float nextAttackTime = 0f;
    private Vector3 scale;
    private Vector3 currentScale;
    private float currentAttackRangeY;
    private float currentAttackRangeX;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1") && rb.bodyType != RigidbodyType2D.Static)
            {
                Attack();
            }
        }

        Scale();
    }

    private void Attack()
    {
        
        attackSound.Play();
        nextAttackTime = Time.time + attackRate;
        Debug.Log(nextAttackTime);
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRangeSize, 1);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemy_health>().TakeDamage(attackDamage);
            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireCube(attackPoint.position, new Vector3(currentAttackRangeX, currentAttackRangeY, 1));
    }

    private void Scale()
    {
        scale = transform.localScale;
        if (scale != currentScale)
        {
            currentAttackRangeY = attackRangeY * scale.y;
        }
        currentAttackRangeX = attackRangeX * scale.x;
        attackRangeSize = new Vector2(attackRangeX, attackRangeY);
        currentScale = scale;
    }
}
