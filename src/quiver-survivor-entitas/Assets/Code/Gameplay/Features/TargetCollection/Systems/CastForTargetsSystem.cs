using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;
        private List<GameEntity> _buffer = new List<GameEntity>(64);

        public CastForTargetsSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.ReadyToCollectTargets,
                GameMatcher.WorldPosition,
                GameMatcher.Radius,
                GameMatcher.LayerMask
            ));
        }
        
        public void Execute()
        {
            foreach (var gameEntity in _ready.GetEntities(_buffer))
            {
                gameEntity.TargetsBuffer.AddRange(TargetsInRadius(gameEntity));
                gameEntity.isReadyToCollectTargets = false;
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity gameEntity)
        {
            return _physicsService.CircleCast(gameEntity.WorldPosition, gameEntity.Radius, gameEntity.LayerMask)
                .Select(e => e.Id);
        }
    }
}