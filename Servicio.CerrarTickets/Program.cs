using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Servicio.CerrarTickets;

var hostBuilder = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // Agrega esta línea para habilitar el soporte de servicio de Windows
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    });

var host = hostBuilder.Build();

await host.RunAsync();

