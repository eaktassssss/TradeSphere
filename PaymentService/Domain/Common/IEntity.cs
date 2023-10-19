namespace PaymentService.Domain.Common
{
    public interface IEntity<out Key> : IEntity where Key : IEquatable<Key>
    {
        public Key Id { get; }

    }
    public interface IEntity
    {
    }
}
