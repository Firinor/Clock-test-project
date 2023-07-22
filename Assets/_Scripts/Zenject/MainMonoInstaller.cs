using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    [SerializeField]
    private TimeGetter timeGetter;

    public override void InstallBindings()
    {
        Container.Bind<TimeView>().AsSingle();
        Container.Bind<TimeData>().AsSingle();
        Container.Bind<TimeAcquisitionAPI>().AsSingle();
        Container.BindInstance(timeGetter).AsSingle();
    }
}