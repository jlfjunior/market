using Market.Api.Models;
using Market.Api.Validations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Market.Test.Units
{
    public class OrderTest
    {
        [Fact]
        public void ShouldValidOrder()
        {
            var order = new Order
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Items = new List<OrderItem> { new OrderItem { OrderId = 1, Description = "Notebook Dell", Quantity = 1, Amount = 1 } }
            };

            var orderValidator = new OrderValidator().Validate(order);

            Assert.True(orderValidator.IsValid);
        }

        [Fact]
        public void ShouldNotValidOrder()
        {
            var order = new Order();

            var orderValidator = new OrderValidator().Validate(order);

            Assert.False(orderValidator.IsValid);
        }
    }
}
