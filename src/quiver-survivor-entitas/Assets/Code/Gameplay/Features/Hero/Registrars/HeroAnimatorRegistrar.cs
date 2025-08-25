using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        public override void RegistrerComponents()
        {
            Entity.AddHeroAnimator(_heroAnimator)
                .AddDamageTakenAnimator(_heroAnimator);
        }

        public override void UnregistrerComponents()
        {
            if (Entity.hasHeroAnimator)
                Entity.RemoveHeroAnimator();

            if (Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}