using UnityEngine;

public class BF_MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 3f;
    
    private Rigidbody2D rb;
    private int targetIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Transform target = waypoints[targetIndex];

        Vector2 direction = target.position - transform.position;
        
        rb.linearVelocity = direction.normalized*speed;


        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % waypoints.Length;
        }
    }
}