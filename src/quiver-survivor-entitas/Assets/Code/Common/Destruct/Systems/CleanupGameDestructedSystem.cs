using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destruct.Systems
{
    public class CleanupGameDestructedSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _entites;
        private List<GameEntity> _buffer = new List<GameEntity>(64);

        public CleanupGameDestructedSystem(GameContext gameContext) => _entites = gameContext.GetGroup(GameMatcher.Destructed);

        public void Cleanup()
        {
            foreach (var gameEntity in _entites.GetEntities(_buffer))
                gameEntity.Destroy();
        }
    }
}