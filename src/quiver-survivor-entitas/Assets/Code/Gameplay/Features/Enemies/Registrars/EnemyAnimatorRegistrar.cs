using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        public override void RegistrerComponents()
        {

            Entity
                .AddEnemyAnimator(_enemyAnimator)
                .AddDamageTakenAnimator(_enemyAnimator);
        }

        public override void UnregistrerComponents()
        {
            if (Entity.hasEnemyAnimator)
                Entity.RemoveEnemyAnimator();

            if (Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}