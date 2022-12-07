using UnityEngine;

public class Spikehead : trap_damage
{
    [Header("Spikehead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[2];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;

    

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        // Move spikehead to destination only if attacking
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();

    //check if spikehead sees player in all 4 directions
    for (int i = 0; i < directions.Length; i++)
    {
        Debug.DrawRay(transform.position, directions[i], Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections()
    {
       // directions[0] = transform.right * range; //right direction
       // directions[1] = -transform.right * range; //left direction
        directions[0] = transform.up * range; //up direction
        directions[1] = -transform.up * range; //down direction
    }
    private void Stop()
    {
        destination = transform.position; //Set destination as current position so it doesn't move
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        base.OnTriggerEnter2D(collision);
        Stop(); // Stop spikehead once he hits something
    }
}
