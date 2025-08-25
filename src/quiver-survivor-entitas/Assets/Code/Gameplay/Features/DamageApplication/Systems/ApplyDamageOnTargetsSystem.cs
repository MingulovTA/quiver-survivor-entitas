using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        
        private readonly IGroup<GameEntity> _damageDealers;

        public ApplyDamageOnTargetsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _damageDealers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.Damage));
        }

        public void Execute()
        {
            foreach (var damageDealer in _damageDealers)
            foreach (int targetId in damageDealer.TargetsBuffer)
            {
                var targetEntity = _gameContext.GetEntityWithId(targetId);
                if (targetEntity.hasCurrentHealth)
                {
                    targetEntity.ReplaceCurrentHealth(targetEntity.CurrentHealth - damageDealer.Damage);
                    
                    if (targetEntity.hasDamageTakenAnimator)
                        targetEntity.DamageTakenAnimator.PlayDamageTaken();
                }
            }
        }
    }
}