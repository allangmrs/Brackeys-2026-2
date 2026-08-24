using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace TransitionSystem
{
    public class FadeTransition : SceneTransition
    {
        public override TransitionType Type => TransitionType.Fade;

        [SerializeField] private RectTransform panel;
        [SerializeField] private CanvasGroup canvasGroup;

        public override IEnumerator Cover()
        {
            panel.gameObject.SetActive(true);

            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = true;

            panel.anchoredPosition = Vector2.zero;

            yield return canvasGroup
                .DOFade(1f, coverDuration)
                .SetEase(coverEase)
                .SetUpdate(true)
                .WaitForCompletion();
        }

        public override IEnumerator Reveal()
        {
            yield return canvasGroup
                .DOFade(0f, revealDuration)
                .SetEase(revealEase)
                .SetUpdate(true)
                .WaitForCompletion();

            canvasGroup.blocksRaycasts = false;

            ResetBaseSettings();
        }
    }
}