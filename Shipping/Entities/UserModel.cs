using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shipping.Entities
{
    public class UserModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }=ObjectId.GenerateNewId().ToString();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        



    }
}