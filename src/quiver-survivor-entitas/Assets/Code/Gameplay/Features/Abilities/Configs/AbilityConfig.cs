using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities
{
    [CreateAssetMenu(menuName = "ECS Survivors", fileName = "abilityConfig")]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId AbilityId;
        public List<AbilityLevel> Levels;
    }
}