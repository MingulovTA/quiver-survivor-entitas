using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private const float DEATH_ANIMATION_TIME = 2;
        
        private IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy, 
                GameMatcher.Dead,
                GameMatcher.ProcessingDead));
        }
        public void Execute()
        {
            foreach (var enemy in _enemies)
            {
                //Todo enemy.REmoveTargetCollectionComponents();
                
                
                if (enemy.hasEnemyAnimator)
                    enemy.EnemyAnimator.PlayDied();
                
                enemy.ReplaceSelfDestructTimer(DEATH_ANIMATION_TIME);
            }
        }
    }
}