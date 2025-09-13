namespace Code.Gameplay.Features.Cooldowns
{
    public static class CooldownEntityExtentions
    {
        public static GameEntity PutOnCooldown(this GameEntity gameEntity)
        {
            if (!gameEntity.hasCooldown)
                return gameEntity;
            gameEntity.isCooldownUp = false;
            gameEntity.ReplaceCooldownLeft(gameEntity.Cooldown);
            return gameEntity;
        }
        
        public static GameEntity PutOnCooldown(this GameEntity gameEntity, float cooldown)
        {
            gameEntity.isCooldownUp = false;
            gameEntity.ReplaceCooldown(cooldown);
            gameEntity.ReplaceCooldownLeft(cooldown);
            return gameEntity;
        }
    }
}