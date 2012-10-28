using System.Web.Mvc;
using BusinessLayer.Facade;
using BusinessLayer.Repository;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Patterns.Specification.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());

            container.Register(
                Component.For<PersonRepository>());
            container.Register(
                Component.For<PersonFacade>());
        }
    }
}