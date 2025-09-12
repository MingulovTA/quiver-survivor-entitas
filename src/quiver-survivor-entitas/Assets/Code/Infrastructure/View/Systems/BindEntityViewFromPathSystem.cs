using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
    public class BindEntityViewFromPathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IEntityViewFactory _entityViewFactory;

        public BindEntityViewFromPathSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AllOf(
                    GameMatcher.View, 
                    GameMatcher.ViewPath)));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                _entityViewFactory.CreateViewForEntity(entity);
            }
        }
    }
}