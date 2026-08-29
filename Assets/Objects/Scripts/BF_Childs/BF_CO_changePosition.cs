using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using TreeEditor;

public class BF_CO_changePosition : BF_ChangeObject
{

    [SerializeField] Vector3 newPos;
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
            transform.position = newPos;
        }
        else
        {
            transform.position = originalPos;
        }
        
    }

    public override void ResetObject()
    {
        base.ResetObject();

        transform.position = originalPos;
    }


}
