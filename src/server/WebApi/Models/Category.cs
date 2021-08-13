using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApi.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool StatusFlag { get; set; }
    }
}
