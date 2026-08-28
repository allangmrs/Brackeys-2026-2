using DG.Tweening;
using UnityEngine;

namespace TransitionSystem
{
    public abstract class TransitionConfigurator : MonoBehaviour
    {
        [Header("Duration")]
        [SerializeField, Min(0f)] protected float coverDuration = 0.5f;
        [SerializeField, Min(0f)] protected float revealDuration = 0.5f;

        [Header("Ease")]
        [SerializeField] protected Ease coverEase = Ease.OutCubic;
        [SerializeField] protected Ease revealEase = Ease.InCubic;

        public abstract void Configure();

        protected void ConfigureBase(SceneTransition transition)
        {
            transition.SetDurations(
                coverDuration,
                revealDuration
            );

            transition.SetEases(
                coverEase,
                revealEase
            );
        }
    }
}