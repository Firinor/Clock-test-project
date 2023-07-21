using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TimeView>().AsSingle();
        Container.Bind<TimeData>().AsSingle();
    }
}