using System.Collections;
using UnityEngine;


public class BF_ChangeObject : MonoBehaviour
{
    [SerializeField] BF_DetectPlayer detector;

    [SerializeField] bool reset = false;
    [SerializeField] bool resetDetector = false;
    [SerializeField] float resetTime;

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

    protected virtual void ChangeObject()
    {
        if (reset)
            StartCoroutine(CorReset());

        // Classes filhas vão dar override
    }

    public virtual void ResetObject()
    {
    
        state = false;
        detector.playerDetected = false;

        // Classes filhas vão dar override
    }

    IEnumerator CorReset()
    {
        yield return new WaitForSeconds(resetTime);

        if (!resetDetector)
            detector.detectorEnabled = false;

        ResetObject();
    }

}
