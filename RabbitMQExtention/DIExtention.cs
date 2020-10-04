using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQExtention
{
    public static class DIExtention
    {
        public static IServiceCollection SimpleRabbitMQInjection(this IServiceCollection services)
        {
            services.AddScoped<IPublishQueue, PublishQueue>();

            return services;
        }
    }
}
