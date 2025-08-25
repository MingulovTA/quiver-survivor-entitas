using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    public class LifetimeComponents
    {
        [Game] public class CurrentHealth                  : IComponent { public float Value; }
        [Game] public class MaxHealth                  : IComponent { public float Value; }
    }
}