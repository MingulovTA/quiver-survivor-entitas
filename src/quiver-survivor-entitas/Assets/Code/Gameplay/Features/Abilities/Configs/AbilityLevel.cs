using System;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Abilities
{
    [Serializable]
    public class AbilityLevel
    {
        public float Cooldown;
        public EntityBehaviour ViewPrefab;
        public ProjectTileSetup ProjectTileSetup;
    }
}