namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext)
        {
            Add(new SetHeroDirectionByInputSystem(gameContext));
        }
    }
}