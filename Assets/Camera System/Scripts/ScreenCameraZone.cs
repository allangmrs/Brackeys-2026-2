using UnityEngine;

namespace CameraSystem
{
    public class ScreenCameraZone : MonoBehaviour
    {
        [SerializeField] private Transform cameraPoint;
        public Transform CameraPoint => cameraPoint;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ScreenCameraController.Instance.SetScreen(this);
            }
        }
    }
}