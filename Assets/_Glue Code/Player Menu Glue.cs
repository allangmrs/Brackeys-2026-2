using MenuSystem;
using MobileControls;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuGlue : MonoBehaviour
{
    private PauseMenuController pauseMenuController;
    private PauseHandler pauseHandler;
    private bool isPaused = false;

    private void Start()
    {
        pauseMenuController = PauseMenuController.Instance;
    }

    private void OnEnable()
    {
        InputHandler.OnPausePressed += TogglePause;
        PauseMenuController.OnReturnToMenu += TogglePause;
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }
    private void OnDisable()
    {
        InputHandler.OnPausePressed -= TogglePause;
        PauseMenuController.OnReturnToMenu -= TogglePause;
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    public void TogglePause()
    {
        Debug.Log("PAUESI PORRA" + isPaused);
        isPaused = !isPaused;
        pauseMenuController.TogglePause(isPaused);

        if (pauseHandler != null)
        {
            pauseHandler.TogglePause(isPaused);
        }
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pauseHandler = FindAnyObjectByType<PauseHandler>();
    }

}
