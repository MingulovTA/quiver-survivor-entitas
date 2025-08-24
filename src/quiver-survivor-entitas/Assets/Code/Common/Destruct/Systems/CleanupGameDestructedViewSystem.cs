using Entitas;
using UnityEngine;

namespace Code.Common.Destruct.Systems
{
    public class CleanupGameDestructedViewSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _entites;

        public CleanupGameDestructedViewSystem(GameContext gameContext)
        {
            _entites = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destructed,
                GameMatcher.View
            ));
        }

        public void Cleanup()
        {
            foreach (var gameEntity in _entites)
            {
                gameEntity.View.ReleaseEntity();
                Object.Destroy(gameEntity.View.gameObject);
            }
        }
    }
}