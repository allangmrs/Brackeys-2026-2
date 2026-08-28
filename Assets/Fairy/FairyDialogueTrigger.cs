using System.Collections;
using DialogueSystem;
using UnityEngine;

namespace Fairy
{
    [RequireComponent(typeof(Collider2D))]
    public class FairyDialogueTrigger : MonoBehaviour
    {
        [SerializeField] private FairyController fairyController;
        [SerializeField] private DialogueData dialogue;
        [SerializeField] private FairyDialoguePoint talkingPoint;
        [SerializeField] private bool triggerOnce = true;
        
        private Collider2D triggerCollider;
        private bool hasTriggered = false;
        private bool isRunning = false;

        private void Awake()
        {
            triggerCollider = GetComponent<Collider2D>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player"))
                return;

            if (isRunning)
                return;

            if (triggerOnce && hasTriggered)
                return;

            if (triggerOnce)
            {
                hasTriggered = true;
                triggerCollider.enabled = false;
            }

            isRunning = true;
            StartCoroutine(StartDialogue());
        }

        private IEnumerator StartDialogue()
        {
            yield return fairyController.GoToPoint(talkingPoint);

            DialogueController.Instance.StartDialogue(
                dialogue,
                () => {
                    fairyController.ResumeFollowing();
                    isRunning = false;
                });
        }
    }
}
