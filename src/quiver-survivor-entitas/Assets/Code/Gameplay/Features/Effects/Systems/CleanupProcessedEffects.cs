using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class CleanupProcessedEffects : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _Effects;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupProcessedEffects(GameContext gameContext)
        {
            _Effects = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Effect,
                GameMatcher.Processed));
        }

        public void Cleanup()
        {
            foreach (var effect in _Effects.GetEntities(_buffer))
            {
                effect.Destroy();
            }
        }
    }
}