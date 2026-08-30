using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class BF_CO_changePosition : BF_ChangeObject
{
    [SerializeField] bool triggerOnce;
    [SerializeField] Transform newPos;
    Vector3 originalPos;


    protected override void Awake()
    {
        base.Awake();

        originalPos = transform.position;
    }

    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void ChangeObject()
    {
        base.ChangeObject();

        if (transform.position == originalPos)
        {
            transform.position = new Vector3(newPos.position.x, newPos.position.y, newPos.position.z);
        }
        else
        {
            transform.position = originalPos;
        }

        if (!reset && !triggerOnce)
        {
            base.ResetObject();
        }
        
        
    }

    public override void ResetObject()
    {
        base.ResetObject();
        
        transform.position = originalPos;
    }


}
