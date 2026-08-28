using UnityEngine;

public class BF_DetectPlayer : MonoBehaviour
{
    public bool playerDetected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerDetected)
        {
            playerDetected = true;
            Debug.Log("Viu player");
        }
    }
}
