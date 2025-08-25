using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CollectTargetsIntervalSystem : IExecuteSystem
    {
        private ITimeService _timeService;
        private IGroup<GameEntity> _entities;

        public CollectTargetsIntervalSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.CollectTargetsInterval,
                GameMatcher.CollectTargetsTimer));
        }
        
        public void Execute()
        {
            foreach (var gameEntity in _entities)
            {
                gameEntity.ReplaceCollectTargetsTimer(gameEntity.CollectTargetsTimer - _timeService.DeltaTime);
                
                if (gameEntity.CollectTargetsTimer <= 0)
                {
                    gameEntity.ReplaceCollectTargetsTimer(gameEntity.CollectTargetsInterval);
                    gameEntity.isReadyToCollectTargets = true;
                }
            }
        }
    }
}