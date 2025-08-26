using System.Collections.Generic;
using Entitas;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new List<GameEntity>(64);
        private readonly IGroup<GameEntity> _entities;

        public MarkDeadSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.CurrentHealth,
                GameMatcher.MaxHealth).NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (var gameEntity in _entities.GetEntities(_buffer))
            {
                if (gameEntity.CurrentHealth <= 0)
                {
                    gameEntity.isDead = true;
                    gameEntity.isProcessingDead = true;
                }
            }
        }
    }
}