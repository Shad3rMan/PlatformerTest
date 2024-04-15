using Core.Infrastructure.Controllers;
using VContainer;

namespace Platformer.Gameplay.Core
{
	public class ControllerFactory<TController> :  IControllerFactory<TController> where TController : Controller
	{
		private readonly IObjectResolver _resolver;

		public ControllerFactory(IObjectResolver resolver)
		{
			_resolver = resolver;
		}
		
		public TController Create()
		{
			return _resolver.Resolve<TController>();
		}
	}
}