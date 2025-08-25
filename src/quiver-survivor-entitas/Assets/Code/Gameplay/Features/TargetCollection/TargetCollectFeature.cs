using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public class TargetCollectFeature : Feature
    {
        public TargetCollectFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CollectTargetsIntervalSystem>());
            Add(systemFactory.Create<CastForTargetsSystem>());
            Add(systemFactory.Create<CleanUpTargetBuffersSystem>());
        }
    }
}