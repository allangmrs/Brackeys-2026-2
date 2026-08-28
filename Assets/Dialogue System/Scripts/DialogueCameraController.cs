using DG.Tweening;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueCameraController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private float dialogueZoom = 4f;
        [SerializeField] private float transitionDuration = 0.3f;
        [SerializeField] private Vector2 framingOffset;

        private Vector3 originalPosition;
        private float originalZoom;

        private void Awake()
        {
            originalPosition = mainCamera.transform.position;
            originalZoom = mainCamera.orthographicSize;
        }

        public void FocusBetween(Transform obj1, Transform obj2)
        {
            Vector3 midpoint = (obj1.position + obj2.position) / 2f;

            midpoint += (Vector3)framingOffset;

            Vector3 targetPosition = new Vector3(
                midpoint.x,
                midpoint.y,
                originalPosition.z
            );

            mainCamera.transform
                .DOMove(targetPosition, transitionDuration)
                .SetEase(Ease.OutQuad);

            mainCamera
                .DOOrthoSize(dialogueZoom, transitionDuration)
                .SetEase(Ease.OutQuad);
        }

        public void ResetCamera()
        {
            mainCamera.transform
                .DOMove(originalPosition, transitionDuration)
                .SetEase(Ease.OutQuad);

            mainCamera
                .DOOrthoSize(originalZoom, transitionDuration)
                .SetEase(Ease.OutQuad);
        }
    }
}