using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Common.Destruct.Systems
{
    public class SelfDestructTimerSystem : IExecuteSystem
    {
        private ITimeService _timeService;
        private IGroup<GameEntity> _entites;
        private List<GameEntity> _buffer = new List<GameEntity>(64);

        public SelfDestructTimerSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            _entites = gameContext.GetGroup(GameMatcher.SelfDestructTimer);
        }
        
        public void Execute()
        {
            foreach (var gameEntity in _entites.GetEntities(_buffer))
            {
                if (gameEntity.SelfDestructTimer > 0)
                {
                    gameEntity.ReplaceSelfDestructTimer(gameEntity.SelfDestructTimer - _timeService.DeltaTime);
                }
                else
                {
                    gameEntity.RemoveSelfDestructTimer();
                    gameEntity.isDestructed = true;
                }
            }
        }
    }
}