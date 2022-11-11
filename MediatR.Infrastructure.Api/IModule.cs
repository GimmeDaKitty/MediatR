using System.Threading.Tasks;
using Autofac;

namespace MediatR.Infrastructure.Api
{
    public interface IModule
    {
        /// <summary>
        ///     Returns a <see cref="Task" /> that represents the asynchronous operation of loading in the module
        /// </summary>
        Task LoadAsync(ContainerBuilder containerBuilder);
    }
}