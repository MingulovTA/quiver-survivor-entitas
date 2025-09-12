using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class FinalizeHeroDeathProcessingSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new List<GameEntity>(4);
        private readonly IGroup<GameEntity> _enemies;

        public FinalizeHeroDeathProcessingSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Dead,
                GameMatcher.ProcessingDead));
        }

        public void Execute()
        {
            foreach (var hero in _enemies.GetEntities(_buffer))
                hero.isProcessingDead = false;
        }
    }
}
        
     