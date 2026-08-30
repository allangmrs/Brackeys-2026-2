using UnityEngine;
using DG.Tweening;
using AudioSystem;

public class BF_CO_objectScale : BF_ChangeObject
{
    [SerializeField] Vector2 scaleMultTarget;
    [SerializeField] float timeToTarget;
    [SerializeField] bool startColliderDisabled = false;
    [SerializeField] private AudioClip scaleSFX;
    [SerializeField] bool changeSprite = false;
    [SerializeField] Sprite spriteOriginal;
    [SerializeField] Sprite spriteNovo;

    SpriteRenderer spriteRenderer;
    Vector3 originalScale;
    Collider2D objCollider;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        
        objCollider = GetComponent<Collider2D>();

        if (startColliderDisabled)
        {
            objCollider.enabled = false;
        }
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

        if (scaleSFX != null)
        {
            AudioManager.Instance.PlaySFX(null, scaleSFX);
        }
        if (changeSprite)
            spriteRenderer.sprite = spriteNovo;

        transform.DOScale(Vector3.Scale(scaleMultTarget, transform.localScale), timeToTarget);

        if (startColliderDisabled)
        {
            objCollider.enabled = true;
        }
       

        //transform.localScale = new Vector3 (3,10,1);
        //spriteRenderer.color = Color.red;
    }

    public override void ResetObject()
    {
        base.ResetObject();

        if (changeSprite)
            spriteRenderer.sprite = spriteOriginal;

        transform.DOScale(originalScale, timeToTarget);

        if (startColliderDisabled)
        {
            objCollider.enabled = false;
        }

        Debug.Log("Resetou");
    }
}
