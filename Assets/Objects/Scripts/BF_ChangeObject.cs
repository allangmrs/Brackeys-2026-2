using UnityEngine;


public class BF_ChangeObject : MonoBehaviour
{
    [SerializeField] BF_DetectPlayer detector;
    protected bool state = false;


    protected virtual void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (detector.playerDetected && !state)
        {
            ChangeObject();

            state = true;
        }
    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected virtual void ChangeObject ()
    {
        // Classes filhas vão dar override
    }

}
