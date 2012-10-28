using System.Web.Mvc;
using BusinessLayer.Builder;
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
                Component.For<PersonRepository>().LifestyleSingleton());
            container.Register(
                Component.For<SpecificationBuilder>());
            container.Register(
                Component.For<IPersonFacade>()
                .ImplementedBy<PersonFacade>());

             
        }
    }
}