using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shipping.Entities
{
    public record ShippingService
    {
        [Key]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShippingServiceId { get; set; }=ObjectId.GenerateNewId().ToString();

        public string CarrierId { get; set; }
        public virtual ServiceProviderEntity ServiceProvider { get; set; }

        public virtual List<Package> Packages { get; set; }


    }
}