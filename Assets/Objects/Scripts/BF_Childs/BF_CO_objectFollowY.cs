using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class BF_CO_objectFollowY : BF_ChangeObject
{
    public float vel;

    Transform player;

    

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (state)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (transform.position.x, player.position.y), Time.deltaTime * vel);
        }
            
    }

    protected override void ChangeObject()
    {
        base.ChangeObject();

    }


}
