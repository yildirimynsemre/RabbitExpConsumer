using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitExp003Consumer.Data
{
    public abstract class MongoBaseModel
    {
        public ObjectId Id { get; set; }
    }
}
