using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class DestructOnZeroHealthSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DestructOnZeroHealthSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.CurrentHealth);
        }
        
        public void Execute()
        {
            foreach (var gameEntity in _entities)
            {
                if (gameEntity.CurrentHealth <= 0)
                    gameEntity.isDestructed = true;
            }
        }
    }
}