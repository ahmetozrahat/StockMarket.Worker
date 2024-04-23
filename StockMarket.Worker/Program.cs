using StockMarket.Worker;
using StockMarket.Worker.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddInfrastructureServices();

var host = builder.Build();
host.Run();