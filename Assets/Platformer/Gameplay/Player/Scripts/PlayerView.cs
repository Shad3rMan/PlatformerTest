using UnityEngine;

namespace Platformer.Gameplay.Player
{
	public class PlayerView : MonoBehaviour
	{
		public const string Address = "HeroKnight";

		[SerializeField]
		private SpriteRenderer _playerRenderer;

		[SerializeField]
		private Rigidbody2D _playerRigidbody;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private float _playerSpeed = 4f;

		[SerializeField]
		private float _jumpForce = 7.5f;

		private static readonly int AirSpeedHash = Animator.StringToHash("AirSpeedY");
		private static readonly int JumpHash = Animator.StringToHash("Jump");
		private static readonly int GroundedHash = Animator.StringToHash("Grounded");


		public void SetFacingDirection(int direction)
		{
			_playerRenderer.flipX = direction == 1;
		}

		public void Move(float speed)
		{
			var currentVelocity = _playerRigidbody.velocity;
			currentVelocity = new Vector2(speed * _playerSpeed, currentVelocity.y);
			_animator.SetFloat(AirSpeedHash, currentVelocity.y);
			_playerRigidbody.velocity = currentVelocity;
		}

		public void Jump()
		{
			_animator.SetTrigger(JumpHash);
			_animator.SetBool(GroundedHash, false);
			_playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
		}
	}
}