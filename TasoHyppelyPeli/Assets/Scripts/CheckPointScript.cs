using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
       anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.lastCheckpointPos = transform.position;
            anim.SetBool("IsTriggered", true);
        }
    }
}