using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly Vector3 FAR_AWAY = new Vector3(15478,15478,0);
        
        private IAssetProvider _assetProvider;
        private IInstantiator _instantiator;

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        public EntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            var viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab, FAR_AWAY, Quaternion.identity, null);
            view.SetEntity(entity);
            return view;
        }
        
        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.ViewPrefab, FAR_AWAY, Quaternion.identity, null);
            view.SetEntity(entity);
            return view;
        }
    }
}