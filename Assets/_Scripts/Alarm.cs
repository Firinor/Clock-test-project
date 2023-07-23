using System;
using TMPro;
using UnityEngine;
using Zenject;

public class Alarm : MonoBehaviour
{
    [Inject]
    private TimeData timeData;
    [Inject]
    private AlarmData alarmData;
    [Inject]
    private AlarmView alarmView;
    [Inject]
    private BackgroundTaskAlarm backgroundTaskAlarm;

    public void OnFieldEndEdit(TMP_InputField input)
    {
        if (DateTime.TryParse(input.text, out DateTime time))
        {
            SetAlarm(time);
        }
        else
        {
            ResetAlarm();
        }
    }

    public void SetAlarm(DateTime time)
    {
        alarmData.isAlarmEnabled = true;
        alarmData.AlarmTime = time;
        alarmView.SetAlarmTime(time);
        backgroundTaskAlarm.EnableAlarm();
    }

    public void ResetAlarm()
    {
        alarmData.isAlarmEnabled = false;
        alarmView.ClearAlarmTime();
    }

    public void StartToSetNewAlarm()
    {
        alarmView.StartNewAlarmTime();
    }
}
