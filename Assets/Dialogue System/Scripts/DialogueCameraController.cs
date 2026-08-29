using DG.Tweening;
using UnityEngine;
using CameraSystem;

namespace DialogueSystem
{
    public class DialogueCameraController : MonoBehaviour
    {
        [SerializeField] private Vector2 framingOffset;

        public void FocusBetween(Transform obj1, Transform obj2)
        {
            ScreenCameraController.Instance.FocusBetween(
                obj1,
                obj2,
                framingOffset
            );
        }

        public void ResetCamera()
        {
            ScreenCameraController.Instance.ResetToScreen();
        }
    }
}