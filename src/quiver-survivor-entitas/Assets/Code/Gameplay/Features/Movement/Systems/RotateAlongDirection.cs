using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class RotateAlongDirection : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public RotateAlongDirection (GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RotationAlignedAlongDirection,
                    GameMatcher.Transform,
                    GameMatcher.Direction));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.Direction.sqrMagnitude >= 0.01f)
                {
                    var angle = Mathf.Atan2(entity.Direction.y, entity.Direction.x) * Mathf.Rad2Deg;
                    entity.Transform.rotation = Quaternion.Euler(0,0,angle);
                }
            }
        }
    }
}