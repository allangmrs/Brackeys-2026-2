using Player;
using UnityEngine;

public class BF_CheckPointManager : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private EffectsController effectsController;
    public BF_CheckPoint activeCheckPoint; // Checkpoint atual

    Transform transformPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        DeathDetector.OnPlayerDeathCompleted += RespawnPlayer;
        BF_CheckPoint.OnPlayerCheckPoint += UpdateCheckPoint;
    }

    void OnDisable()
    {
        DeathDetector.OnPlayerDeathCompleted -= RespawnPlayer;
        BF_CheckPoint.OnPlayerCheckPoint -= UpdateCheckPoint;
    }



    void Start()
    {
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespawnPlayer()
    {
        transformPlayer.position = activeCheckPoint.transformCheckPoint.position;
        
        effectsController.PlaySpawnEffects();

        inputHandler.EnableInputs();

        activeCheckPoint.ResetCOs();
    }

    void UpdateCheckPoint(BF_CheckPoint newCheckPoint)
    {
        if (activeCheckPoint == newCheckPoint)
            return;

        activeCheckPoint = newCheckPoint;
    }
}
