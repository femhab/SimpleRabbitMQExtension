using MassTransit;
using System;
using System.Threading.Tasks;

namespace RabbitMQExtention
{
    public interface IPublishQueue
    {
        Task Create<T>(string topic, T model) where T : class;
    }

    public class PublishQueue : IPublishQueue
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public PublishQueue(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Create<T>(string topic, T model) where T : class
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + topic));

            await endpoint.Send<T>(new { model });
        }
    }
}

//public static IServiceCollection AddInjectedServices(this IServiceCollection services)
//{
//    services.AddTransient<IPublishQueue, PublishQueue>();
//    return services;
//}
