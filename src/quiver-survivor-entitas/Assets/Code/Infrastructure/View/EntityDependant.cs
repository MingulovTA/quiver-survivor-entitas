using System;
using UnityEngine;

namespace Code.Infrastructure.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityView;

        public GameEntity Entity => EntityView != null ? EntityView.GameEntity : null;

        private void Awake()
        {
            if (!EntityView)
            {
                EntityView = GetComponent<EntityBehaviour>();
            }
        }
    }
}