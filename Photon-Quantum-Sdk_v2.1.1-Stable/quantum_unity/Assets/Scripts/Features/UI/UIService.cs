using Zenject;
public abstract class UIService : IInitializable {
	[Inject]
	protected ServerData ServerData;
	public abstract void Initialize();
}
