using System.Threading.Tasks;
using Core.Infrastructure.Controllers;

namespace Platformer.Gameplay.Core.GameInitialisation
{
	public class GameStartController : Controller
	{
		private readonly PlayerInitialisationController _playerInitController;

		public GameStartController(PlayerInitialisationController playerInitController)
		{
			_playerInitController = playerInitController;
		}

		protected override Task Running()
		{
			AddChildController(_playerInitController);
			return Task.CompletedTask;
		}
	}
}