using Market.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Market.Api.Services
{
    public class FileService
    {
        private const string DELIMITER = ",";
        public ICollection<Order> Orders { get; set; }

        public FileService()
        {

            var items = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, Description = "Notebook", Quantity = 1, Amount = 20000 },
                new OrderItem { Id = 2, OrderId = 1, Description = "Notebook", Quantity = 1, Amount = 20000 },
                new OrderItem { Id = 3, OrderId = 1, Description = "Notebook", Quantity = 1, Amount = 20000 },
                new OrderItem { Id = 4, OrderId = 1, Description = "Notebook", Quantity = 1, Amount = 20000 }
            };

            Orders = new List<Order>
            {
                new Order { Id = 1, CreatedAt = DateTime.Now, Items = items }
            };
        }

        public string Content()
        {
            var str = new StringBuilder();

            str.Append("OrderId").Append(DELIMITER);
            str.Append("Date").Append(DELIMITER);
            str.Append("ItemId").Append(DELIMITER);
            str.Append("Product").Append(DELIMITER);
            str.Append("Quantity").Append(DELIMITER);
            str.Append("Amount");
            str.AppendLine();

            foreach (var order in Orders)
            {
                foreach (var item in order.Items)
                {
                    str.Append(order.Id).Append(DELIMITER);
                    str.Append(order.CreatedAt).Append(DELIMITER);
                    str.Append(item.Id).Append(DELIMITER);
                    str.Append(item.Description).Append(DELIMITER);
                    str.Append(item.Quantity).Append(DELIMITER);
                    str.Append(item.Amount);
                    str.AppendLine();
                }
            }

            return str.ToString();
        }
    }
}
