using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class BackgroundTaskAlarm : MonoBehaviour
{
    [Inject]
    private TimeData timeData;
    [Inject]
    private AlarmData alarmData;
    [Inject]
    private AlarmSettings alarmSettings;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnableAlarm()
    {
        timeData.NewTimeEvent += CheckAlarm;
    }

    private void CheckAlarm()
    {
        if(!alarmData.isAlarmEnabled)
            DisableAlarm();

        if (TimeIsCome())
            Alarm();
    }

    private void Alarm()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.PlayOneShot(alarmSettings.Clip);
    }

    private bool TimeIsCome()
    {
        return timeData.CurrentTime.Hour == alarmData.AlarmTime.Hour
            && timeData.CurrentTime.Minute == alarmData.AlarmTime.Minute
            && timeData.CurrentTime.Second == alarmData.AlarmTime.Second;
    }

    private void OnDestroy()
    {
        DisableAlarm();
    }

    private void DisableAlarm()
    {
        timeData.NewTimeEvent -= CheckAlarm;
    }
}
