using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shipping.Entities
{
    public record ServiceProviderEntity
    {
        [Key]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CarrierId { get; set; }=ObjectId.GenerateNewId().ToString();
        [Required]
        public virtual List<ShippingService> ShippingService { get; set; }
        
    }
}