using UnityEngine;

namespace Code.Infrastructure.View
{
    public interface IEntityView
    {
        GameEntity GameEntity { get; }
        void SetEntity(GameEntity gameEntity);
        void ReleaseEntity();
        
        GameObject gameObject { get; }
    }
}