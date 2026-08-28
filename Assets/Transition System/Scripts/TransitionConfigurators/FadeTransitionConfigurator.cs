namespace TransitionSystem
{
    public class FadeTransitionConfigurator : TransitionConfigurator
    {
        public override void Configure()
        {
            FadeTransition fade =
                TransitionManager.Instance
                    .GetTransition<FadeTransition>(
                        TransitionType.Fade
                    );

            if (fade == null)
                return;

            ConfigureBase(fade);
        }
    }
}