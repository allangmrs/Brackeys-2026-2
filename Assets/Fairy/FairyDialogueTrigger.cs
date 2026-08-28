using System.Collections;
using DialogueSystem;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fairy
{
    [RequireComponent(typeof(Collider2D))]
    public class FairyDialogueTrigger : MonoBehaviour
    {
        [SerializeField] private FairyController fairyController;
        [SerializeField] private DialogueData dialogue;
        [SerializeField] private FairyDialoguePoint talkingPoint;
        [SerializeField] private bool triggerOnce = true;

        private InputHandler playerInput;
        private DialogueCameraController cameraController;
        private Collider2D triggerCollider;
        private bool hasTriggered = false;
        private bool isRunning = false;

        private void Awake()
        {
            triggerCollider = GetComponent<Collider2D>();
            cameraController = FindAnyObjectByType<DialogueCameraController>();
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
            
            playerInput = collision.transform.root.GetComponentInChildren<InputHandler>();
            playerInput.DisableInputs();

            cameraController.FocusBetween(collision.transform, fairyController.transform);

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
                    playerInput.EnableInputs();
                });
        }
    }
}
