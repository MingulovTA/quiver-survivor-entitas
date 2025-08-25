using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _speed = 2;
        
        public override void RegistrerComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(_speed)
                .AddCurrentHealth(_maxHealth)
                .AddMaxHealth(_maxHealth)
                .With(x=>x.isHero = true)
                .With(x=>x.isTurnedAlongDirection = true)
                ;
        }

        public override void UnregistrerComponents()
        {
            Entity
                .RemoveWorldPosition()
                .RemoveDirection()
                .RemoveSpeed()
                .With(x => x.isHero = false)
                .With(x => x.isTurnedAlongDirection = false)
                ;
        }
    }
}