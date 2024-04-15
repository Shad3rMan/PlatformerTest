using Core.Infrastructure.Controllers;
using VContainer;

namespace Platformer.Gameplay.Core
{
	public static class ContainerExtensions
	{
		public static void RegisterControllerFactory<TController>(this IContainerBuilder builder, Lifetime lifetime) where TController : Controller
		{
			builder.Register<TController>(lifetime);
			builder.Register<IControllerFactory<TController>, ControllerFactory<TController>>(lifetime);
		}
	}
}