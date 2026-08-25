using UnityEngine;

public class BF_UpdateY : MonoBehaviour
{
    public float vel;

    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2 (transform.position.x, player.position.y), Time.deltaTime * vel);
    }
}
