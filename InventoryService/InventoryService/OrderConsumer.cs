using MassTransit;
using Model;

public class OrderConsumer : IConsumer<Order>
{
    public async Task Consume(ConsumeContext<Order> context)
    {
        await Console.Out.WriteLineAsync(context.Message.Name);
    }
}