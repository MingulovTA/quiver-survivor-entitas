namespace Code.Infrastructure.View.Registrars
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegistrerComponents();
        public abstract void UnregistrerComponents();
    }
}