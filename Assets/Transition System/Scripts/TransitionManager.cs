using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TransitionSystem
{
    public class TransitionManager : MonoBehaviour
    {
        public static TransitionManager Instance { get; private set; }

        [Header("Configurações")]
        [SerializeField] private TransitionType defaultTransition = TransitionType.Fade;

        private Dictionary<TransitionType, SceneTransition> transitions;

        public bool IsTransitioning { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            transitions = GetComponentsInChildren<SceneTransition>(true)
                .ToDictionary(transition => transition.Type);
            
            if (!transitions.ContainsKey(defaultTransition))
            {
                Debug.LogError(
                    $"Default transition {defaultTransition} not found",
                    this
                );
            }
        }

        private IEnumerator Start()
        {
            yield return transitions[defaultTransition].Reveal();
        }

        public void LoadScene(SceneName sceneName, TransitionType transitionType)
        {
            if (IsTransitioning) return;

            SceneTransition transition = GetTransition(transitionType);

            StartCoroutine(TransitionRoutine(sceneName, transition));
        }

        public void LoadScene(SceneName sceneName)
        {
            LoadScene(sceneName, defaultTransition);
        }
        
        private IEnumerator TransitionRoutine(SceneName sceneName, SceneTransition transition)
        {
            IsTransitioning = true;

            yield return transition.Cover();

            Time.timeScale = 1f;

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName.ToString());

            yield return asyncLoad;

            yield return transition.Reveal();

            IsTransitioning = false;
        }

        private SceneTransition GetTransition(TransitionType type)
        {
            if (transitions.TryGetValue(type, out SceneTransition transition))
            {
                return transition;
            }
            
            Debug.LogWarning(
                $"Transition of type {type} not found.\n" +
                $" Using default transition. {defaultTransition}",
                this
            );

            return transitions[defaultTransition];
        }

        // nao foi utilizada ainda
        public T GetTransition<T>(TransitionType type) where T : SceneTransition
        {
            if (transitions.TryGetValue(type, out SceneTransition transition) && 
                transition is T typedTransition)
            {
                return typedTransition;
            }

            Debug.LogWarning(
                $"Transition '{type}' of type '{typeof(T).Name}' not found.",
                this
            );

            return null;
        }
    }
}