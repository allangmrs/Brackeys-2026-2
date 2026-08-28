using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        public DialogueCameraController DialogueCameraController;
        [SerializeField] DialogueData dialogue;
        public Transform focuspoint1;
        public Transform focuspoint2;

        public void TriggerDialogue()
        {
            DialogueController.Instance.StartDialogue(dialogue);
            DialogueCameraController.FocusBetween(focuspoint1, focuspoint2);
        }
    }
}