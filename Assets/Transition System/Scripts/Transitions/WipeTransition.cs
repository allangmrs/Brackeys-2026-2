using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace TransitionSystem
{
    

    public class WipeTransition : SceneTransition
    {
        public override TransitionType Type => TransitionType.Wipe;

        [SerializeField] private RectTransform panel;
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Wipe Direction")]
        [SerializeField] private WipeDirection defaultEnterDirection = WipeDirection.Right;
        [SerializeField] private WipeDirection defaultExitDirection = WipeDirection.Left;

        private WipeDirection enterDirection;
        private WipeDirection exitDirection;

        protected override void Awake()
        {
            base.Awake();
            ResetDirections();
        }

        public void SetDirections(WipeDirection enterDirection, WipeDirection exitDirection)
        {
            this.enterDirection = enterDirection;
            this.exitDirection = exitDirection;
        }

        public void ResetDirections()
        {
            enterDirection = defaultEnterDirection;
            exitDirection = defaultExitDirection;
        }

        public override IEnumerator Cover()
        {
            panel.gameObject.SetActive(true);
         
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            Canvas.ForceUpdateCanvases();

            panel.anchoredPosition = GetOffscreenPosition(enterDirection);

            yield return panel
                .DOAnchorPos(Vector2.zero, coverDuration)
                .SetEase(coverEase)
                .SetUpdate(true)
                .WaitForCompletion();
        }

        public override IEnumerator Reveal()
        {
            Canvas.ForceUpdateCanvases();

            Vector2 exitPosition = GetOffscreenPosition(exitDirection);

            yield return panel
                .DOAnchorPos(exitPosition, revealDuration)
                .SetEase(revealEase)
                .SetUpdate(true)
                .WaitForCompletion();

            canvasGroup.blocksRaycasts = false;

            panel.gameObject.SetActive(false);

            ResetDirections();
            ResetBaseSettings();
        }

        private Vector2 GetOffscreenPosition(WipeDirection direction)
        {
            float width = panel.rect.width;
            float height = panel.rect.height;

            return direction switch
            {
                WipeDirection.Left => new Vector2(-width, 0f),
                WipeDirection.Right => new Vector2(width, 0f),
                WipeDirection.Up => new Vector2(0f, height),
                WipeDirection.Down => new Vector2(0f, -height),
                _ => Vector2.zero
            };
        }
    }
}