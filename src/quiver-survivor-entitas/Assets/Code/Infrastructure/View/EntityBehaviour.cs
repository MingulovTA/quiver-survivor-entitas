using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private ICollisionRegistry _collisionRegistry;
        private GameEntity _gameEntity;

        public GameEntity GameEntity => _gameEntity;
        
        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity gameEntity)
        {
            _gameEntity = gameEntity;
            _gameEntity.AddView(this);
            _gameEntity.Retain(this);
            
            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegistrerComponents();


            foreach (var collider2D in GetComponentsInChildren<Collider2D>(true))
                _collisionRegistry.Register(collider2D.GetInstanceID(),_gameEntity);
        }

        public void ReleaseEntity()
        {
            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregistrerComponents();
            
            foreach (var collider2D in GetComponentsInChildren<Collider2D>(true))
                _collisionRegistry.Unregister(collider2D.GetInstanceID());
            
            _gameEntity.Release(this);
            _gameEntity = null;
        }
    }
}