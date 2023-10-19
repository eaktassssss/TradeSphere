using MongoDB.Bson.Serialization.Attributes;
using StockService.Domain.Common;

namespace StockService.Domain.Entities
{
    public class Stock : BaseEntity
    {


        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]
        [BsonElement(Order = 1)]
        public int ProductId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]
        [BsonElement(Order = 2)]
        public int Count { get; set; }
    }
}
