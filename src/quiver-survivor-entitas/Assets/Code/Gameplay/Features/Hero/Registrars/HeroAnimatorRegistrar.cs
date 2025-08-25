using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        public override void RegistrerComponents() => Entity.AddHeroAnimator(_heroAnimator);

        public override void UnregistrerComponents() => Entity.RemoveHeroAnimator();
    }
}