using System;
using System.Collections.Generic;

namespace Core.Infrastructure.Controllers
{
	public abstract class Controller
	{
		private readonly IControllerFactory _factory;
		private readonly List<Controller> _children = new();
		private readonly List<IDisposable> _disposablesList = new();

		protected Controller(IControllerFactory factory)
		{
			_factory = factory;
		}

		protected virtual void Start()
		{
		}

		protected void Terminate()
		{
			foreach (var disposable in _disposablesList)
			{
				disposable.Dispose();
			}

			_disposablesList.Clear();

			foreach (var child in _children)
			{
				child.Terminate();
			}

			_children.Clear();
			OnTerminate();
		}

		protected void AddDisposable(IDisposable disposable)
		{
			if (!_disposablesList.Contains(disposable))
			{
				_disposablesList.Add(disposable);
			}
		}

		protected T AddChildController<T>() where T : Controller
		{
			var controller = _factory.Create<T>();
			_children.Add(controller);
			controller.Start();
			return controller;
		}

		protected void RemoveChildController<T>(T controller) where T : Controller
		{
			controller.Terminate();
			_children.Remove(controller);
		}

		protected virtual void OnTerminate()
		{
		}
	}
}