using System.Collections;
using UnityEngine;

namespace Player.Effects
{
    public class DeathTimeSlow : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;

        public void ApplyEffect()
        {
            StartCoroutine(Routine());
        }

        public void DisableEffect()
        {
            Time.timeScale = 1;
        }

        private IEnumerator Routine()
        {
            float elapsedTime = 0;
            float progress;

            while (elapsedTime < playerEffectsData.slowDuration)
            {
                progress = elapsedTime / playerEffectsData.slowDuration;

                Time.timeScale = Mathf.Lerp(1, 0, progress);

                elapsedTime += Time.unscaledDeltaTime;

                yield return null;
            }

            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            DisableEffect();
        }
    }
}