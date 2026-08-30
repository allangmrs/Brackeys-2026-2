using AudioSystem;
using Player;
using UnityEngine;

public class BF_PlayerKnockback : MonoBehaviour
{
    [SerializeField] float force;

    [SerializeField] bool hasFixedDirection;
    [SerializeField] float fixedDirection = -1;  // -1 == esquerda, 1 == direita
    [SerializeField] AudioClip boing;

    //PlayerBehaviour playerBehaviour;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBehaviour>(out var playerBehaviour))
        {
            float directionX;
            if (hasFixedDirection)
            {
                directionX = Mathf.Sign(collision.transform.position.x - transform.position.x);
            }
            else
            {
                directionX = fixedDirection;
            }

            if (boing != null)
            {
                AudioManager.Instance.PlaySFX(null, boing);
            }
            
            playerBehaviour.ApplyKnockback(force, new Vector2(directionX, 0));
        }

    }
}
