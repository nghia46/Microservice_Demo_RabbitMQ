using MassTransit;
using Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var bus = Bus.Factory.CreateUsingRabbitMq(config =>
{
    config.Host(new Uri("rabbitmq://guest:guest@localhost:5672"));
});
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("rabbitmq://guest:guest@localhost:5672");
    });
});

builder.Services.AddHostedService<MassTransitHostedService>();
builder.Services.AddSingleton(bus);
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
var busControl = app.Services.GetRequiredService<IBusControl>();
await busControl.StartAsync();
app.MapControllers();
app.Run();
