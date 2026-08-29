using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Assets.Bomb
{
    public class Bomb : MonoBehaviour
    {
        [Header("Bomb")]
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private Transform bomb;
        [SerializeField] private float fallTime = 0.5f;
        [SerializeField] private GameObject ground;
        [SerializeField] private Ease bombEase = Ease.InOutQuad;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                BombAttack();
            }
        }

        private void BombAttack() 
        {
            bomb.position = spawnPoint.position;
            bomb.DOMove(targetPoint.position, fallTime).SetEase(bombEase).OnComplete(() => Explode());
        }

        private void Explode()
        {
            bomb.gameObject.SetActive(false);
            ground.SetActive(false);
            // Animação e som de explosão
        }
    }
}