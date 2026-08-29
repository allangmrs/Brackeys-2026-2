using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

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

        public void SetScreen(Transform cameraPoint)
        {
            if (cameraPoint == null || followPoint == null)
            {
                return;
            }

            transitionTween?.Kill();

            transitionTween = followPoint
                .DOMove(cameraPoint.position, transitionTime)
                .SetEase(transitionEase);
        }
    }
}