using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "ScriptableObjects/SettingsInstaller")]
class ScriptableObjectInstaller :ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField]
    private ClockSettings clockSettings;
    [SerializeField]
    private InternetSettings internetSettings;
    [SerializeField]
    private BackgroundTaskSettings backgroundTaskSettings;
    [SerializeField]
    private AlarmSettings alarmSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(clockSettings).AsSingle();
        Container.BindInstance(internetSettings).AsSingle();
        Container.BindInstance(backgroundTaskSettings).AsSingle();
        Container.BindInstance(alarmSettings).AsSingle();
    }
}
