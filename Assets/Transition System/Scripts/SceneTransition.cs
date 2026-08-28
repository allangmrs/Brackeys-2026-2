using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace TransitionSystem
{
    public abstract class SceneTransition : MonoBehaviour
    {
        public abstract TransitionType Type { get; }

        [Header("Default Duration")]
        [SerializeField, Min(0f)] protected float defaultCoverDuration = 0.5f;
        [SerializeField, Min(0f)] protected float defaultRevealDuration = 0.5f;

        [Header("Default Ease")]
        [SerializeField] protected Ease defaultCoverEase = Ease.OutCubic;
        [SerializeField] protected Ease defaultRevealEase = Ease.InCubic;

        protected float coverDuration;
        protected float revealDuration;

        protected Ease coverEase;
        protected Ease revealEase;

        protected virtual void Awake()
        {
            ResetDurations();
            ResetEases();
        }

        public void SetDurations(float coverDuration, float revealDuration)
        {
            this.coverDuration = Mathf.Max(0f, coverDuration);
            this.revealDuration = Mathf.Max(0f, revealDuration);
        }

        public void ResetDurations()
        {
            coverDuration = defaultCoverDuration;
            revealDuration = defaultRevealDuration;
        }

        public void SetEases(Ease coverEase, Ease revealEase)
        {
            this.coverEase = coverEase;
            this.revealEase = revealEase;
        }

        public void ResetEases()
        {
            coverEase = defaultCoverEase;
            revealEase = defaultRevealEase;
        }

        protected void ResetBaseSettings()
        {
            ResetDurations();
            ResetEases();
        }

        public abstract IEnumerator Cover();
        public abstract IEnumerator Reveal();
    }
}