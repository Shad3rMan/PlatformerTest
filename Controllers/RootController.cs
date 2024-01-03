namespace Core.Infrastructure.Controllers
{
	public class RootController : Controller
	{
		public RootController(IControllerFactory factory) : base(factory)
		{
		}

		public void StartTree()
		{
			Start();
		}

		public void TerminateTree()
		{
			Terminate();
		}
	}
}