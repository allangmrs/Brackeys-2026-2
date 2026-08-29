using DG.Tweening;
using UnityEngine;
using System.Collections;
using Player;

namespace Fairy
{
    public class FairyController : MonoBehaviour
    {
        [SerializeField] private Transform playerVisual;
        [SerializeField] private Transform followPoint;
        [SerializeField] private Vector2 followOffset = new Vector2(0f, 1f);

        [SerializeField] private float followSmoothTime = 0.2f;
        [SerializeField] private float flipSpeed = 8f;
        [SerializeField] private Transform visual;

        [Header("Floating")]
        [SerializeField] private float floatAmplitudeY = 0.1f;
        [SerializeField] private float floatSpeedY = 3f;

        [SerializeField] private float floatAmplitudeX = 0.05f;
        [SerializeField] private float floatSpeedX = 2f;

        [Header("Tilt")]
        [SerializeField] private float maxTilt = 10f;
        [SerializeField] private float tiltSpeed = 5f;


        private Vector3 visualStartPosition;
        private Vector3 velocity;
        private bool isFollowing = true;
        private Vector3 previousPosition;
        private Vector3 movementVelocity;

        private void Awake()
        {
            visualStartPosition = visual.localPosition;
            previousPosition = transform.position;
        }

        private void LateUpdate()
        {
            if (!isFollowing) return;
            if (isFollowing)
            {
                FollowPlayer();
                UpdateFacingDirection();
            }

            FollowPlayer();
            UpdateFacingDirection();
            //UpdateDirection();
            UpdateMovementVelocity();
            UpdateFloating();
            UpdateTilt();
        }

        private void FollowPlayer()
        {
            float direction = playerVisual.localScale.x > 0 ? 1f : -1f;

            Vector3 offset = new Vector3(
                followOffset.x * direction,
                followOffset.y,
                0f
            );

            Vector3 targetPosition = followPoint.position + offset;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                followSmoothTime
            );
        }

        private void UpdateDirection()
        {
            float direction =
                playerVisual.position.x - transform.position.x;

            if (Mathf.Abs(direction) < 0.01f)
                return;

            SetFacingDirection(direction > 0);
        }

        private void UpdateFacingDirection()
        {
            bool playerFacingRight = playerVisual.localScale.x > 0;

            SetFacingDirection(playerFacingRight);
        }

        public IEnumerator GoToPoint(FairyDialoguePoint point)
        {
            isFollowing = false;

            transform.DOKill();

            yield return transform
                .DOMove(point.transform.position, 0.5f)
                .SetEase(Ease.OutQuad)
                .WaitForCompletion();

            SetFacingDirection(point.FaceRight);
        }

        // No trigger usa algo como:
        // DialogueController.Instance.StartDialogue(dialogue, fairyController.ResumeFollowing);
        public void ResumeFollowing()
        {
            isFollowing = true;
        }

        private void SetFacingDirection(bool faceRight)
        {
            visual.localScale = new Vector3(!faceRight ? -1 : 1, 1, 1);
        }

        private void UpdateFloating()
        {
            float offsetY = Mathf.Sin(2f * Time.time * floatSpeedY) * floatAmplitudeY;
            float offsetX = Mathf.Sin(Time.time * floatSpeedX) * floatAmplitudeX;

            visual.localPosition = visualStartPosition + new Vector3(offsetX, offsetY, 0f);
        }
        private void UpdateTilt()
        {
            float targetTilt = Mathf.Clamp(
                -movementVelocity.x * 2f,
                -maxTilt,
                maxTilt
            );

            visual.localRotation = Quaternion.Lerp(
                visual.localRotation,
                Quaternion.Euler(0f, 0f, targetTilt),
                tiltSpeed * Time.deltaTime
            );
        }

        private void UpdateMovementVelocity()
        {
            movementVelocity =
                (transform.position - previousPosition) / Time.deltaTime;

            previousPosition = transform.position;
        }
    }
}