using System.Threading.Tasks;
using Core.Infrastructure.Controllers;
using Platformer.Gameplay.Core.GameInitialisation;

namespace Platformer.Gameplay
{
	public class PlatformerRootController : RootController
	{
		private readonly GameStartController _gameStartController;

		public PlatformerRootController(GameStartController gameStartController)
		{
			_gameStartController = gameStartController;
		}

		protected override Task Running()
		{
			AddChildController(_gameStartController);
			return Task.CompletedTask;
		}
	}
}