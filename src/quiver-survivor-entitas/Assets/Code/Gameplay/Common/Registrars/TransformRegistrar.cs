using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegistrerComponents() => Entity.AddTransform(transform);

        public override void UnregistrerComponents() => Entity.RemoveTransform();
    }
}