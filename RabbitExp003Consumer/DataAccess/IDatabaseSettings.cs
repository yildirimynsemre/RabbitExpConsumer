using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitExp003Consumer.DataAccess
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string CollectionName { get; set; }
    }
}
