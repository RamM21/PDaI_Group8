using UnityEngine;
using System.Collections;

public class chameleon_movement : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [Header("Sounds")]
    [SerializeField] private AudioClip walkSound;
    public AudioSource source {get;private set;}
    private bool moving;
    private bool routine;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private Animator anim;

    private void Awake() {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        source.loop=true;
        source.clip=walkSound;
        moving = true;
        routine = false;
        StartCoroutine(sound());
    }
    private void Update() {
        anim.SetBool("moving",moving);
        if(!routine){
        if(movingLeft)
        {
            transform.localScale = new Vector3(5,5,5);
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            {
            movingLeft = false;
            StartCoroutine(watching());
            }
        }
        else
        {
            transform.localScale = new Vector3(-5,5,5);
            if(transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            {
            movingLeft = true;
            StartCoroutine(watching());
            }
        }
        }
    }
    private IEnumerator watching()
    {
        routine = true;
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        moving = false;
        yield return new WaitForSeconds(4);
        StartCoroutine(sound());
        moving = true;
        routine = false;
    }
    private IEnumerator sound()
    {
        yield return new WaitForSeconds((float)0.2);
        source.Play();
        yield return new WaitForSeconds((float)0.3);
        source.Stop();
        if(routine == false)
            StartCoroutine(sound());
    }
}
