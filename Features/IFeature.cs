namespace Core.Infrastructure.Features
{
	public interface IFeature
	{
		bool IsAvailable { get; }
		void Run();
		void Terminate();
	}
}