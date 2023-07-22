using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "ScriptableObjects/SettingsInstaller")]
class ScriptableObjectInstaller :ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    public ClockSettings clockSettings;
    public InternetSettings internetSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(clockSettings).AsSingle();
        Container.BindInstance(internetSettings).AsSingle();
    }
}
