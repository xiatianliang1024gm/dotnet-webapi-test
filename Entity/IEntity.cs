namespace webapi_test.Entity;

public interface IEntity<TKey> 
where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}