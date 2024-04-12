using System.Collections.Generic;

namespace Core.Infrastructure.Features
{
	public abstract class FeatureBootstrapper
	{
		private readonly IEnumerable<IFeature> _features;

		protected FeatureBootstrapper(IEnumerable<IFeature> features)
		{
			_features = features;
		}

		public void RunFeatures()
		{
			foreach (var feature in _features)
			{
				if (feature.IsAvailable)
				{
					feature.Run();
				}
			}
		}
	}
}