using Newtonsoft.Json;
using RabbitExp003Consumer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitExp003Consumer.Models
{
    class PersonJson : MongoBaseModel
    {
        [JsonProperty]
        public string Companies { get; set; }

    }
}
