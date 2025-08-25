using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanUpTargetBuffersSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _entities;

        public CleanUpTargetBuffersSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.TargetsBuffer);
        }
        
        public void Cleanup()
        {
            foreach (var gameEntity in _entities)
                gameEntity.TargetsBuffer.Clear();
        }
    }
}