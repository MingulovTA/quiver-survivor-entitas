using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    public partial class LifetimeComponents
    {
        [Game] public class MaxHealth     : IComponent { public float Value; }

        [Game] public class CurrentHealth : IComponent { public float Value; }
        [Game] public class Dead          : IComponent { }
        [Game] public class ProcessingDead          : IComponent { }
    }
}