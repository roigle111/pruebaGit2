using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;

namespace PersistenceDatabase.Config
{
    public class OrderNumberConfig
    {
        public OrderNumberConfig(EntityTypeBuilder<OrderNumber> entityOptionsBuilder)
        {
            entityOptionsBuilder.HasKey(x => x.Year);
            entityOptionsBuilder.HasData(new OrderNumber
            {
                Year = DateTime.Now.Year,
                Value = 0
            });
        }

    }
}
