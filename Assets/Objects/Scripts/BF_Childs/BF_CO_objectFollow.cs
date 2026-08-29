using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public class BF_CO_objectFollow : BF_ChangeObject
{
    public float vel;
    public bool eixoY = true;

    Transform player;
    Vector3 originalPos;
    bool following = false;

    

    protected override void Awake()
    {
        base.Awake();

        originalPos = transform.position;
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

        if (following)
        {
            if (eixoY)
                transform.position = Vector2.MoveTowards(transform.position, new Vector2 (transform.position.x, player.position.y), Time.deltaTime * vel);
            else
                transform.position = Vector2.MoveTowards(transform.position, new Vector2 (player.position.x, transform.position.y), Time.deltaTime * vel);
        }
        else if (!following && transform.position != originalPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, Time.deltaTime * vel);
        }
            
    }

    protected override void ChangeObject()
    {
        base.ChangeObject();

        following = true;
    }

    public override void ResetObject()
    {
        base.ResetObject();

        following = false;
    }


}
