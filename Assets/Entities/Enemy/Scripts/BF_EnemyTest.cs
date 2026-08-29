using UnityEngine;

public class BF_EnemyTest : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    private bool movingRight = true;

    [Header("Detection")]
    public Transform detectionPoint;
    public float rayDistance = 1f;
    public LayerMask obstacleLayers;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        CheckObstacles();
    }

    void Move()
    {
        float vel;

        if (movingRight)
        {
            vel = moveSpeed;
        }
        else
        {
            vel = -moveSpeed;
        }

        rb.linearVelocity = new Vector2(vel, rb.linearVelocityY);
    }

    void CheckObstacles()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(detectionPoint.position, Vector2.down, rayDistance, obstacleLayers);

        Vector2 forwardDirection;
        if (movingRight)
        {
            forwardDirection = Vector2.right;
        } 
        else
        {
            forwardDirection = Vector2.left;
        }

        RaycastHit2D forwardInfo = Physics2D.Raycast(detectionPoint.position, forwardDirection, rayDistance, obstacleLayers);

        

        if (groundInfo.collider == null || forwardInfo.collider != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;

        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
