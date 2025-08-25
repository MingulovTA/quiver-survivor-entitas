using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private float _speed = 1;
        
        public override void RegistrerComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(_speed)
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