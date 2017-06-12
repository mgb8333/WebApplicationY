using Domain.Implementations;
using Domain.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplicationY.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IMessageItemRepository>().To<MessageItemRepository>();
        }
    }
}