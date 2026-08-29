using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BF_CheckPoint : MonoBehaviour
{
    [SerializeField] List<BF_ChangeObject> COlist;    // Os changeObjects do checkpoint

    public Transform transformCheckPoint;

    public static event Action<BF_CheckPoint> OnPlayerCheckPoint;


    void Awake()
    {
        //transformCheckPoint = transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerCheckPoint?.Invoke(this);
        }
    }

    public void ResetCOs()
    {
        foreach (BF_ChangeObject CO in COlist)
        {
            CO.ResetObject();
        }
    }
}
