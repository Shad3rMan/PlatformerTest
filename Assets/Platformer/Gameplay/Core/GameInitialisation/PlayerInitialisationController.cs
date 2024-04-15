using System.Threading.Tasks;
using Core.Infrastructure.Controllers;
using Core.Infrastructure.Extensions;
using Platformer.Gameplay.Player;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Platformer.Gameplay.Core.GameInitialisation
{
	public class PlayerInitialisationController : Controller
	{
		private readonly PlayerSpawnPoint _spawnPoint;
		private readonly PlayerMovementController _movementController;
		private readonly PlayerInputController _playerInputController;

		public PlayerInitialisationController(
			PlayerSpawnPoint spawnPoint,
			PlayerMovementController movementController,
			PlayerInputController playerInputController)
		{
			_spawnPoint = spawnPoint;
			_movementController = movementController;
			_playerInputController = playerInputController;
		}
		
		protected override async Task Running()
		{
			var resource = await Addressables.LoadAssetAsync<GameObject>(PlayerView.Address).Task;
			AddDisposable(resource.AsDisposable());
			var playerGo = Object.Instantiate(resource, _spawnPoint.Position, Quaternion.identity);
			AddDisposable(playerGo.AsDisposable());
			
			var playerView = playerGo.GetComponent<PlayerView>();
			_movementController.SetPlayerView(playerView);
			AddChildController(_movementController);
			AddChildController(_playerInputController);
		}
	}
}