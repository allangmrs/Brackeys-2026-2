using MenuSystem;
using MobileControls;
using Player;
using UnityEngine;

public class PlayerMenuGlue : MonoBehaviour
{
    private PauseMenuController pauseMenuController;
    private PauseHandler pauseHandler;
    private bool isPaused = false;

    private void Start()
    {
        pauseMenuController = PauseMenuController.Instance;
        pauseHandler = FindAnyObjectByType<PauseHandler>();
    }

    private void OnEnable()
    {
        InputHandler.OnPausePressed += TogglePause;
        PauseMenuController.OnReturnToMenu += TogglePause;
    }
    private void OnDisable()
    {
        InputHandler.OnPausePressed -= TogglePause;
        PauseMenuController.OnReturnToMenu -= TogglePause;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuController.TogglePause(isPaused);
        pauseHandler.TogglePause(isPaused);
    }

}
