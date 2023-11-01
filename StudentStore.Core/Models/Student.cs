using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentStore.Core.Models
{
    //if the JSON document in MongoDB contains more fields than the properties in the corresponding C# class, can use this attribute
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]//the property Id maps to _id field in Mongo document.
        [BsonRepresentation(BsonType.ObjectId)]//attribute automatically converts Mongo data type to a .Net data type and vice-versa
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
