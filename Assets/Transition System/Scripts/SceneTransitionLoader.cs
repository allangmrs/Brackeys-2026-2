using DG.Tweening;
using UnityEngine;

namespace TransitionSystem
{
    public class SceneTransitionLoader : MonoBehaviour
    {
        [SerializeField] private SceneName targetScene;
        [SerializeField] private TransitionType transitionType;

        [SerializeField] private TransitionConfigurator configurator;

        public void LoadScene()
        {
            configurator?.Configure();

            TransitionManager.Instance.LoadScene(
                targetScene,
                transitionType
            );
        }
    }
}