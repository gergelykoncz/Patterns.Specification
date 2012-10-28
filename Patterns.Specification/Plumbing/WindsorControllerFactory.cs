using System;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace Patterns.Specification.Plumbing
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("Controller for path '{0}' cannot be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)_kernel.Resolve(controllerType);
        }
    }
}