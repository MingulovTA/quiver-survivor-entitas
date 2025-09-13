using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyEffectOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IEffectFactory _effectFactory;
        
        private readonly IGroup<GameEntity> _entities;

        public ApplyEffectOnTargetsSystem(GameContext gameContext, IEffectFactory effectFactory)
        {
            _gameContext = gameContext;
            _effectFactory = effectFactory;
            _entities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.EffectSetups));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetsBuffer)
            foreach (var effectSetup in entity.EffectSetups)
            {
                _effectFactory.CreateEffect(effectSetup, ProducerId(entity), targetId);
            }
        }

        private static int ProducerId(GameEntity gameEntity)
        {
            return gameEntity.hasProducerId ? gameEntity.ProducerId : gameEntity.Id;
        }
    }
}