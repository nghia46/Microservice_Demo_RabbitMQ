using MassTransit;
using Model;

public class OrderConsumer : IConsumer<Order>
{
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public OrderConsumer(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task Consume(ConsumeContext<Order> context)
    {
        var order = context.Message;
        OrderResponse response = new OrderResponse { Status = $"{order.Name}" };
        if (order.Name.Equals("string")) return;
        await Console.Out.WriteLineAsync(order.Name);
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:status_queue"));
        await endpoint.Send(response);
    }
}
