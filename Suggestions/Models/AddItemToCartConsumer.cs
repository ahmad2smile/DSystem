using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cart;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Suggestions.Models
{
    public class AddItemToCartConsumer: IConsumer<AddItemReply>
    {
        private readonly ILogger<AddItemToCartConsumer> _logger;

        public AddItemToCartConsumer(ILogger<AddItemToCartConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<AddItemReply> context)
        {
            var data = context.Message;

            _logger.Log(LogLevel.Information, $"User: {data.UserId}, like Item: {data.ItemId}");

            return Task.FromResult(0);
        }
    }
}
