namespace UrlShortener.Data.Entities.Base;
public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public DateTime Created { get; private set; }

    public BaseEntity()
    {
        Id = ObjectId.GenerateNewId();
        Created = DateTime.UtcNow;
    }
}