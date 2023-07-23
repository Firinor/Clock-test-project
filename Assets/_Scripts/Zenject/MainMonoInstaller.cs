using TMPro;
using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    [SerializeField]
    private TimeGetter timeGetter;
    [SerializeField]
    private BackgroundTaskTimeCheck backgroundTask;
    [SerializeField]
    private TMP_InputField inputField;

    public override void InstallBindings()
    {
        Container.Bind<TimeData>().AsSingle();
        Container.Bind<AlarmData>().AsSingle();

        Container.Bind<AlarmView>().AsSingle();
        Container.Bind<TimeView>().AsSingle().NonLazy();
        Container.Bind<TimeAcquisitionAPI>().AsSingle();

        Container.BindInstance(backgroundTask).AsSingle();
        Container.BindInstance(timeGetter).AsSingle();
        Container.BindInstance(inputField).AsSingle();
    }
}