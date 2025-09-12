using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new List<GameEntity>(64);
        private readonly IGroup<GameEntity> _enemies;

        public FinalizeEnemyDeathProcessingSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy, 
                GameMatcher.Dead,
                GameMatcher.ProcessingDead));
        }
        
        public void Execute()
        {
            foreach (var enemy in _enemies.GetEntities(_buffer))
            {
                enemy.isProcessingDead = false;
            }
        }
    }
}