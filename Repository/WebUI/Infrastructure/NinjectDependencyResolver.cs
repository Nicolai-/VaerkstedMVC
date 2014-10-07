using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Moq;
using Repository.Abstract;
using Repository.Concrete.Entities;
using System.Linq;
using Repository.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            //Mock<IGenericRepository<Customer>> mock = new Mock<IGenericRepository<Customer>>();

            //IQueryable<Customer> customers = (new List<Customer>
            //{
            //    new Customer { Id = 1, Name = "Jørgen Hansen", Company = "Jørgen Hansen Biler", Phone = 75467589 },
            //    new Customer { Id = 2, Name = "Klaus Jensen", Phone = 55446677 },
            //    new Customer { Id = 3, Name = "Jakob Jensen", Phone = 33333333 }
            //}).AsQueryable();
            //mock.Setup(m => m.GetAll()).Returns(customers);

            //kernel.Bind<IGenericRepository<Customer>>().ToConstant(mock.Object);

            //Create CustomerController
            kernel.Bind<IGenericRepository<Customer>>().To<GenericRepository<Customer>>().WithConstructorArgument("dbContext", new VaerkstedContext());

            //Create CarController
            kernel.Bind<ICarRepository>().To<CarRepository>().WithConstructorArgument("dbContext", new VaerkstedContext());


        }
    }
}