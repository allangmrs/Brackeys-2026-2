using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace TransitionSystem
{
    public class TransitionTrigger : MonoBehaviour
    {
        [SerializeField] private bool Trigger = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Trigger)
            {
                SceneTransitionLoader loader = GetComponent<SceneTransitionLoader>();
                if (loader != null)
                {
                    loader.LoadScene();
                }
            }
        }
    }
}