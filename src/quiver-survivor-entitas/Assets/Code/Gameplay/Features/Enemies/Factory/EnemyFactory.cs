using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector2 at)
        {
            switch (enemyTypeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
            }
            throw  new Exception($"Enemy with type id {enemyTypeId} does not exists");
        }

        private GameEntity CreateGoblin(Vector2 at)
        {
            //Todo Закинуть константы в конфиг SD
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddEnemyTypeId(EnemyTypeId.Goblin)
                    .AddWorldPosition(at)
                    .AddDirection(Vector2.zero)
                    .AddSpeed(1)
                    .AddCurrentHealth(3)
                    .AddMaxHealth(3)
                    .AddDamage(1)
                    .AddTargetsBuffer(new List<int>(1))
                    .AddRadius(.3f)
                    .AddCollectTargetsInterval(.5f)
                    .AddCollectTargetsTimer(0)
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .AddEnemyTypeId(EnemyTypeId.Goblin)
                    .With(x => x.isTurnedAlongDirection = true)
                    .With(x => x.isEnemy = true)
                    .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}