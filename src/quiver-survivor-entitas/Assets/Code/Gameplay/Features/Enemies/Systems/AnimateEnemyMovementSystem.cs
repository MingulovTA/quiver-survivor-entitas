using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class AnimateEnemyMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

        public AnimateEnemyMovementSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.EnemyAnimator));
        }
        
        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                /*if (enemy.isMoving)
                    enemy.EnemyAnimator.
                else
                {
                    enemy.EnemyAnimator.PlayIdle();
                }*/
            }
        }
    }
}