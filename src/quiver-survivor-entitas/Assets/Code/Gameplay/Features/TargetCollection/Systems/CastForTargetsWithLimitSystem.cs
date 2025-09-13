using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;
        private List<GameEntity> _buffer = new List<GameEntity>(64);
        private GameEntity[] _targetCastBuffer = new GameEntity[128];

        public CastForTargetsWithLimitSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.ReadyToCollectTargets,
                GameMatcher.WorldPosition,
                GameMatcher.Radius,
                GameMatcher.ProcessedTargets,
                GameMatcher.TargetLimit,
                GameMatcher.LayerMask
            ));
        }
        
        public void Execute()
        {
            foreach (var gameEntity in _ready.GetEntities(_buffer))
            {
                for (int i = 0; i < Math.Min(TargetCountInRadius(gameEntity),gameEntity.TargetLimit); i++)
                {
                    int targetId = _targetCastBuffer[i].Id;
                    if (!AlreadyProcessed(gameEntity, targetId))
                    {
                        gameEntity.TargetsBuffer.Add(targetId);
                        gameEntity.ProcessedTargets.Add(targetId);
                    }
                }
                
                if (!gameEntity.isCollectingTargetsContinuously)
                    gameEntity.isReadyToCollectTargets = false;
            }
        }

        private bool AlreadyProcessed(GameEntity gameEntity, int targetId)
        {
            return gameEntity.ProcessedTargets.Contains(targetId);
        }

        private int TargetCountInRadius(GameEntity gameEntity)
        {
            return _physicsService.CircleCastNonAlloc(gameEntity.WorldPosition, gameEntity.Radius,
                gameEntity.LayerMask, _targetCastBuffer);
        }

        public void TearDown()
        {
            _targetCastBuffer = null;
        }
    }
}