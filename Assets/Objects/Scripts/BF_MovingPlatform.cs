using UnityEngine;

public class BF_MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private float speed = 3f;
    
    private Rigidbody2D rb;
    private int targetIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 target = waypoints[targetIndex];

        float direction = Mathf.Sign(target.x - transform.position.x);
        
        rb.linearVelocityX = direction*speed;


        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % waypoints.Length;
        }
    }
}