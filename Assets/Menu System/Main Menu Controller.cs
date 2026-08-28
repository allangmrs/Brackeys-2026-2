using UnityEngine;

namespace MenuSystem
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("Sections")]
        [SerializeField] private BaseSection startSection;
        [SerializeField] private BaseSection configSection;
        [SerializeField] private BaseSection controlsSection;
        [SerializeField] private BaseSection creditsSection;

        public void StartNewGame()
        {
            Debug.Log("Começando novo jogo!");
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }

        public void OpenConfigSection()
        {
            configSection.Activate(null);
            PauseMenuController.Instance.TogglePause(true);
        }
        public void CloseConfigSection()
        {
            configSection.Deactivate();
            PauseMenuController.Instance.TogglePause(false);
        }

        public void OpenControlsSection() { controlsSection.Activate(null); }
        public void CloseControlsSection() { controlsSection.Deactivate(); }

        public void OpenCreditsSection() { creditsSection.Activate(null); }
        public void CloseCreditsSection() { creditsSection.Deactivate(); }
    }
}