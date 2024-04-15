using System.Threading.Tasks;
using Core.Infrastructure.Controllers;
using VContainer.Unity;

namespace Platformer.Gameplay.Player
{
	public class PlayerMovementController : Controller, ITickable
	{
		private readonly PlayerInput _playerInput;
		private PlayerView _playerView;
		private bool _isInitialized;

		public PlayerMovementController(PlayerInput playerInput)
		{
			_playerInput = playerInput;
		}

		public void SetPlayerView(PlayerView playerView)
		{
			_playerView = playerView;
			_isInitialized = true;
		}

		protected override Task Running()
		{
			return Task.CompletedTask;
		}

		public void Tick()
		{
			if (!_isInitialized)
			{
				return;
			}
			
			var horizontalInput = _playerInput.Horizontal;

			if (horizontalInput > 0)
			{
				_playerView.SetFacingDirection(-1);
			}
			else if (horizontalInput < 0)
			{
				_playerView.SetFacingDirection(1);
			}

			_playerView.Move(horizontalInput);

			if (_playerInput.Jump)
			{
				_playerView.Jump();
			}
		}
	}
}