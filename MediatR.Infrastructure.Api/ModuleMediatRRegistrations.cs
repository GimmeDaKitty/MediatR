using System.Reflection;
using Autofac;

namespace MediatR.Infrastructure.Api
{
    public static class ModuleMediatRRegistrations
    {
        public static void RegisterMediatRServices<T>(ContainerBuilder builder)
            where T : class
        {
            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>) 
                //,
                // typeof(IRequestExceptionHandler<,,>),
                // typeof(IRequestExceptionAction<,>),
                // typeof(INotificationHandler<>),
                // typeof(IStreamRequestHandler<,>)
            };
            
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(T).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
        }
    }
}