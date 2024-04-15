using System.Threading.Tasks;
using Core.Infrastructure.Controllers;
using UnityEngine;
using VContainer.Unity;

namespace Platformer.Gameplay.Player
{
	public class PlayerInputController : Controller, ITickable
	{
		private readonly PlayerInput _playerInput;

		public PlayerInputController(PlayerInput playerInput)
		{
			_playerInput = playerInput;
		}
		
		protected override Task Running()
		{
			return Task.CompletedTask;
		}

		public void Tick()
		{
			_playerInput.Horizontal = Input.GetAxis("Horizontal");
			_playerInput.Jump = Input.GetKeyDown(KeyCode.Space);
		}
	}
}