using Core.Infrastructure.Controllers;

namespace Core.Infrastructure
{
	public abstract class EntryPoint<T> where T : RootController
	{
		private RootController RootController { get; set; }

		protected EntryPoint(T rootController)
		{
			RootController = rootController;
		}

		protected void Initialize()
		{
			RootController.StartTree();
		}
	}
}