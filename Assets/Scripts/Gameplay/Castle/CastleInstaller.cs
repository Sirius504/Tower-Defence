using Zenject;

public class CastleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Health>().FromNew().AsSingle();
    }
}