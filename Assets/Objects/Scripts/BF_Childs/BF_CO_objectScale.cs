using UnityEngine;
using DG.Tweening;

public class BF_CO_objectScale : BF_ChangeObject
{
    [SerializeField] Vector3 scaleTarget;
    [SerializeField] float timeToTarget;
    SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        transform.DOScale(scaleTarget, timeToTarget);
       

        //transform.localScale = new Vector3 (3,10,1);
        spriteRenderer.color = Color.red;
    }
}
