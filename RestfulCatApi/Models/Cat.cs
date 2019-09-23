using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCatApi.Models
{
    public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
