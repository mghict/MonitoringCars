using Moneyon.Common.Collections;
using Moneyon.Common.IOC;
using System.Reflection;

namespace API.IOC
{
    public class ServiceRegistrationUtil
    {
        private readonly IServiceCollection services;
        private readonly string environmentName;
        private readonly string assemblyStartName;

        public ServiceRegistrationUtil(IServiceCollection services, string environmentName, string assemblyStartName)
        {
            this.services = services;
            this.environmentName = environmentName;
            this.assemblyStartName = assemblyStartName;
        }

        /// <summary>
        /// Registers all services into the IOC container
        /// </summary>
        public void RegisterServices()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().FullName.StartsWith(assemblyStartName));
            var types = assemblies.SelectMany(item => item.GetTypes());
            types.ForEach(type =>
            {
                var attr = type.GetCustomAttribute<AutoRegisterAttribute>(false);
                if (attr != null && (attr.Environments == null || attr.Environments.Contains(this.environmentName)))
                {
                    if (attr.ServiceInterface != null)
                    {
                        services.AddTransient(attr.ServiceInterface, type);
                    }
                    else
                    {
                        services.AddTransient(type);
                    }
                }
            });
        }
    }
}
