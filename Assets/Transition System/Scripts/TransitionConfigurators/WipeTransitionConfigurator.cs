using UnityEngine;

namespace TransitionSystem
{
    public class WipeTransitionConfigurator : TransitionConfigurator
    {
        [Header("Direction")]
        [SerializeField] private WipeDirection enterDirection = WipeDirection.Right;
        [SerializeField] private WipeDirection exitDirection = WipeDirection.Left;

        public override void Configure()
        {
            WipeTransition wipe =
                TransitionManager.Instance
                    .GetTransition<WipeTransition>(
                        TransitionType.Wipe
                    );

            if (wipe == null)
                return;

            ConfigureBase(wipe);

            wipe.SetDirections(
                enterDirection,
                exitDirection
            );
        }
    }
}