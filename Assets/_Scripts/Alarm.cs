using System;
using TMPro;
using UnityEngine;
using Zenject;

public class Alarm : MonoBehaviour
{
    [Inject]
    private TimeData timeData;
    [Inject]
    private TimeView timeView;
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

        ResetClockState();
    }
    public void OnEditAlarm(TMP_InputField input)
    {
        alarmView.OnEditAlarm(input);
    }
    private void ResetClockState()
    {
        alarmView.OnEndAlarmSelect();
        timeView.HandsGoWithTick();
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
        timeView.HandsDontGoWithTick();
        alarmView.SelectNewAlarmTime();
    }
}
