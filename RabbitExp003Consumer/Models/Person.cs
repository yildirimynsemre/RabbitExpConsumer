using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitExp003Consumer.Models
{
    public class Person
    {
        [BsonElement("FİrstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public int LastName { get; set; }
        [BsonElement("Number")]
        public int Number { get; set; }
        [BsonElement("Country")]
        public string Country { get; set; }
    }
}
