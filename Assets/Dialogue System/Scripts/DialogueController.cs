using System;
using UnityEngine;
using TMPro;
using System.Collections;

namespace DialogueSystem
{
    public class DialogueController : MonoBehaviour
    {
        public static DialogueController Instance { get; private set; }

        [Header("UI")]
        [SerializeField] private GameObject dialogueUI;
        [SerializeField] private TMP_Text dialogueText;
        
        [Header("Typing")]
        [SerializeField] private float typingSpeed = 0.05f;

        [Header("Camera")]
        [SerializeField] private DialogueCameraController cameraController;

        private DialogueData currentDialogue;

        private int currentLine;

        private Coroutine typingCoroutine;

        private bool isTyping;

        public bool IsActive { get; private set; }
        private Action onDialogueFinished;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void StartDialogue(DialogueData dialogue, Action onFinished = null)
        {
            if (dialogue == null || dialogue.Lines.Count == 0)
            {
                return;
            }
            currentDialogue = dialogue;
            currentLine = 0;
            IsActive = true;

            onDialogueFinished = onFinished;

            dialogueUI.SetActive(true);

            ShowCurrentLine();
        }

        public void Continue()
        {
            if (!IsActive)
                return;

            if (isTyping)
            {
                FinishTyping();
                return;
            }

            if (currentLine >= currentDialogue.Lines.Count - 1)
            {
                EndDialogue();
                return;
            }

            currentLine++;

            ShowCurrentLine();
        }

        public void ShowCurrentLine()
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            typingCoroutine = StartCoroutine(TypeLine(currentDialogue.Lines[currentLine]));
        }

        private IEnumerator TypeLine(string line)
        {
            isTyping = true;

            dialogueText.text = line;
            dialogueText.maxVisibleCharacters = 0;
            dialogueText.ForceMeshUpdate();

            int characterCount = dialogueText.textInfo.characterCount;

            for (int i = 0; i < characterCount; i++)
            {
                dialogueText.maxVisibleCharacters = i + 1;

                char character = dialogueText.textInfo.characterInfo[i].character;

                float delay = typingSpeed;

                if (character == '.' ||
                    character == '!' ||
                    character == '?')
                {
                    delay *= 5f;
                }
                else if (character == ',' ||
                         character == ';')
                {
                    delay *= 2f;
                }

                yield return new WaitForSeconds(delay);
            }

            isTyping = false;
            typingCoroutine = null;
        }

        private void FinishTyping()
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            dialogueText.maxVisibleCharacters =
                dialogueText.textInfo.characterCount;

            isTyping = false;
            typingCoroutine = null;
        }

        public void EndDialogue()
        {
            IsActive = false;
            currentDialogue = null;
            dialogueUI.SetActive(false);
            onDialogueFinished?.Invoke();
            onDialogueFinished = null;

            if (cameraController != null)
            {
                cameraController.ResetCamera();
            }
            

        }
    }
}
