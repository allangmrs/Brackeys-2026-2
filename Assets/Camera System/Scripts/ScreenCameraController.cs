using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Device;

namespace CameraSystem
{
    public class ScreenCameraController : MonoBehaviour
    {
        public static ScreenCameraController Instance { get; private set; }

        [Header("Screen Transition Settings")]
        [SerializeField] private Ease transitionEase = Ease.InOutQuad;
        [SerializeField] private float transitionTime = 0.5f;
        [SerializeField] private CinemachineCamera currentCamera;
        [SerializeField] private Transform followPoint;

        private ScreenCameraZone currentScreen;
        private Tween transitionTween;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            followPoint = currentCamera.Follow;
        }

        public void SetScreen(ScreenCameraZone screen)
        {
            if (screen == null || followPoint == null)
            {
                return;
            }

            currentScreen = screen;
            MoveTo(screen.CameraPoint.position);
        }

        public void FocusBetween(Transform obj1, Transform obj2, Vector2 offset)
        {
            if (obj1 == null || obj2 == null || followPoint == null)
            {
                return;
            }

            Vector3 midpoint = (obj1.position + obj2.position) / 2f;
            midpoint += (Vector3)offset;

            MoveTo(midpoint);
        }

        public void ResetToScreen()
        {
            if (currentScreen == null)
                return;

            MoveTo(currentScreen.CameraPoint.position);
        }

        private void MoveTo(Vector3 position)
        {
            transitionTween?.Kill();

            position.z = followPoint.position.z;

            transitionTween = followPoint
                .DOMove(position, transitionTime)
                .SetEase(transitionEase);
        }
    }
}