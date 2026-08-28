using UnityEngine;
using DG.Tweening;

public class BF_CO_objectScale : BF_ChangeObject
{
    [SerializeField] Vector2 scaleMultTarget;
    [SerializeField] float timeToTarget;

    SpriteRenderer spriteRenderer;
    Vector3 originalScale;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
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

        transform.DOScale(Vector3.Scale(scaleMultTarget, transform.localScale), timeToTarget);
       

        //transform.localScale = new Vector3 (3,10,1);
        //spriteRenderer.color = Color.red;
    }

    protected override void ResetObject()
    {
        base.ResetObject();

        transform.DOScale(originalScale, timeToTarget);

        Debug.Log("Resetou");
    }
}
