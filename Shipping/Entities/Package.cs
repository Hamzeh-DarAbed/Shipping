using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shipping.Entities
{
    public record Package
    {
        [Key]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PackageId { get; set; }=ObjectId.GenerateNewId().ToString();
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public string ShippingServiceId { get; set; }
        public virtual ShippingService ShippingService { get; set; }

    }
}