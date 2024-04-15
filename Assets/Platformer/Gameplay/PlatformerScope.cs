using Platformer.Gameplay.Core.GameInitialisation;
using Platformer.Gameplay.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Platformer.Gameplay
{
	public class PlatformerScope : LifetimeScope
	{
		[SerializeField]
		private PlayerSpawnPoint _spawnPoint;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterEntryPoint<PlatformerEntryPoint>(Lifetime.Scoped);
			builder.Register<PlatformerRootController>(Lifetime.Scoped);
			builder.Register<GameStartController>(Lifetime.Scoped);
			builder.Register<PlayerInitialisationController>(Lifetime.Scoped);
			builder.Register<PlayerMovementController>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
			builder.Register<PlayerInputController>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
			builder.Register<PlayerInput>(Lifetime.Scoped);
			builder.RegisterInstance(_spawnPoint);
		}
	}
}