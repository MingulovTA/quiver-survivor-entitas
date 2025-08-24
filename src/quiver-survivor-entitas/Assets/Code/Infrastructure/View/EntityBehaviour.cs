using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _gameEntity;

        public GameEntity GameEntity => _gameEntity;

        public void SetEntity(GameEntity gameEntity)
        {
            _gameEntity = gameEntity;
            _gameEntity.AddView(this);
            _gameEntity.Retain(this);
            
            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegistrerComponents();
        }

        public void ReleaseEntity()
        {
            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregistrerComponents();
            
            _gameEntity.Release(this);
            _gameEntity = null;
        }
    }
}