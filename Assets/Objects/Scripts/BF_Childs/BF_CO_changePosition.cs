using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class BF_CO_changePosition : BF_ChangeObject
{

    [SerializeField] Vector3 newPos;


    protected override void Awake()
    {
        base.Awake();
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

        transform.localPosition = newPos;
    }


}
