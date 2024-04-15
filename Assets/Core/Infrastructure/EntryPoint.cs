using Core.Infrastructure.Controllers;

namespace Core.Infrastructure
{
	public abstract class EntryPoint<T> where T : RootController
	{
		private readonly RootController _rootController;

		protected EntryPoint(T rootController)
		{
			_rootController = rootController;
		}

		protected void Initialize()
		{
			_rootController.RunTree();
		}
	}
}