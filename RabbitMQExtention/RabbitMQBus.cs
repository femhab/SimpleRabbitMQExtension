using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace RabbitMQExtention
{
    public class RabbitMQBus
    {
        public static IBusControl ConfigureBus(IServiceProvider provider, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(config =>
            {
                var host = config.Host(new Uri(BusConstants.RabbitMqUri), hst =>
                {
                    hst.Username(BusConstants.Username);
                    hst.Password(BusConstants.Password);
                });

                config.ConfigureEndpoints(provider);
                registrationAction?.Invoke(config, host);
            });
        }
    }
}
