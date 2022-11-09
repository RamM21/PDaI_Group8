using UnityEngine;

public class slime_movement : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private Animator anim;
    private Rigidbody2D body;

    private void Awake() {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    private void Update() {
        if(movingLeft)
        {
            transform.localScale = new Vector3(5,5,5);
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            movingLeft = false;
        }
        else
        {
            transform.localScale = new Vector3(-5,5,5);
            if(transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y,transform.position.z);
            }
            else
            movingLeft = true;
        }
    }
}
