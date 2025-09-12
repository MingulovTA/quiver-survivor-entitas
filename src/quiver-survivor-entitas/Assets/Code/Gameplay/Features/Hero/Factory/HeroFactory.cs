using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;
        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector2 at)
        {
            //Todo Закинуть константы в конфиг SD
            return CreateEntity.Empty()
                    .AddWorldPosition(at)
                    .AddDirection(Vector2.zero)
                    .AddSpeed(3)
                    .AddCurrentHealth(100)
                    .AddMaxHealth(100)
                    .AddViewPath("Gameplay/Hero/hero")
                    .With(x=>x.isHero = true)
                    .With(x=>x.isTurnedAlongDirection = true)
                    .With(x=>x.isMovementAvailable = true)
                ;
        }
    }
}