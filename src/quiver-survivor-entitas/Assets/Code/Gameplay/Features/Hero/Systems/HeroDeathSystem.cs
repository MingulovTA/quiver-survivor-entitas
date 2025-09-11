using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero, 
                GameMatcher.Dead,
                GameMatcher.HeroAnimator,
                GameMatcher.ProcessingDead));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            {
                hero.HeroAnimator.PlayDied();
            }
        }
    }
}