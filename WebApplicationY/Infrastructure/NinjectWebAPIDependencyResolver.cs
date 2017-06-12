using Domain.Implementations;
using Domain.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;

namespace WebApplicationY.Infrastructure
{
    public class NinjectWebAPIDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public IKernel Container
        {
            get { return _kernel; }
        }

        public NinjectWebAPIDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }

        private void AddBindings()
        {
            //_kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            _kernel.Bind<IMessageItemRepository>().To<MessageItemRepository>();
        }
    }

}