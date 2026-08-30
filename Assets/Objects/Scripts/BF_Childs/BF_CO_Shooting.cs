using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using TreeEditor;

public class BF_CO_Shooting : BF_ChangeObject
{
    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float velProj;
    [SerializeField] float timeDestroy;
    [SerializeField] bool hasFixedDirection;
    [SerializeField] float directionX;
    [SerializeField] float directionY;

    Transform playerTransform;

    


    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Start()
    {
        base.Start();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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

        Vector2 direction;
        if (!hasFixedDirection)
        {
            direction = playerTransform.transform.position - transform.position;
            direction.Normalize();
        }
        else
        {
            direction = new Vector2(directionX, directionY);
        }

        GameObject newProj = Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(Vector3.forward, new Vector2(directionX, directionY)));
        newProj.GetComponent<Rigidbody2D>().linearVelocity = direction*velProj;

        Destroy(newProj, timeDestroy);

    }

    public override void ResetObject()
    {
        base.ResetObject();
    }


}
