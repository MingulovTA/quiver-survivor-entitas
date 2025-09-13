using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId, AbilityConfig> _abitilyById;
    public void LoadAll()
    {
      LoadAbilities();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abitilyById.TryGetValue(abilityId, out var abilityConfig))
        return abilityConfig;
      
      throw new Exception($"Ability config for {abilityId} was not found");
    }

    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      var config = GetAbilityConfig(abilityId);

      if (level > config.Levels.Count)
        level = config.Levels.Count;
      return config.Levels[level - 1];
    }

    private void LoadAbilities()
    {
      _abitilyById = Resources.LoadAll<AbilityConfig>("Configs/Abilities")
        .ToDictionary(x => x.AbilityId, x => x);
    }
  }
}