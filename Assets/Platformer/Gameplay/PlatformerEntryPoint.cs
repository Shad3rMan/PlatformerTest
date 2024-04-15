using Core.Infrastructure;
using UnityEngine;
using VContainer.Unity;

namespace Platformer.Gameplay
{
	public class PlatformerEntryPoint : EntryPoint<PlatformerRootController>, IStartable
	{
		public PlatformerEntryPoint(PlatformerRootController rootController) : base(rootController)
		{
		}

		public void Start()
		{
			Debug.LogWarning("Start");
			Initialize();
		}
	}
}