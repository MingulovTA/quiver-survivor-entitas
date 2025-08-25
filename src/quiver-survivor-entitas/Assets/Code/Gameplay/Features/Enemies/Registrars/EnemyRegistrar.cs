using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private float _maxHealth = 3;
        [SerializeField] private float _damage = 1;
        [SerializeField] private float _speed = 1;

        public override void RegistrerComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(_speed)
                .AddCurrentHealth(_maxHealth)
                .AddMaxHealth(_maxHealth)
                .AddDamage(_damage)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(.3f)
                .AddCollectTargetsInterval(.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .AddEnemyTypeId(EnemyTypeId.Goblin)
                .With(x=>x.isTurnedAlongDirection = true)
                .With(x=>x.isEnemy = true)
                ;
        }

        public override void UnregistrerComponents()
        {
            Entity
                .RemoveWorldPosition()
                .RemoveDirection()
                .RemoveSpeed()
                .RemoveEnemyTypeId()
                .With(x => x.isTurnedAlongDirection = false)
                ;
        }
    }
}