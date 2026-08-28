using UnityEngine;

public class BF_PlatformVelEffect : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Rigidbody2D activePlatformRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float targetWalkVelocity = playerRb.linearVelocityX;

        if (activePlatformRb != null)
        {
            targetWalkVelocity += activePlatformRb.linearVelocity.x;
            
            if (Mathf.Abs(playerRb.linearVelocity.y - activePlatformRb.linearVelocity.y) < 0.1f)
            {
                playerRb.linearVelocity = new Vector2(targetWalkVelocity, activePlatformRb.linearVelocity.y);
                return;
            }

            Debug.Log(activePlatformRb.linearVelocity.x);
        }

        playerRb.linearVelocity = new Vector2(targetWalkVelocity, playerRb.linearVelocity.y);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("Subiu em plataforma");
            activePlatformRb = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        }
    }

    // Detect platform exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Rigidbody2D>() == activePlatformRb)
        {
            activePlatformRb = null;
        }
    }
}
