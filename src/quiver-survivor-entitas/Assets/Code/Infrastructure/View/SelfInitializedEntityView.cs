using System;
using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class SelfInitializedEntityView : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _entityBehaviour;

        private IIdentifierService _identifierService;
        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        private void Awake()
        {
            GameEntity gameEntity = CreateEntity
                .Empty()
                .AddId(_identifierService.Next());
            
            _entityBehaviour.SetEntity(gameEntity);
        }
    }
}