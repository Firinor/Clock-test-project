using System;
using UnityEngine;
using Zenject;

public class AlarmView
{
    [Inject]
    private ViewComponents viewComponents;
    [Inject]
    private AlarmData alarmData;
    [Inject]
    private ClockSettings clockSettings;

    public void SetAlarmTime(DateTime time)
    {
        string timeString = time.ToString(clockSettings.timeFormat);
        viewComponents.AlarmInputField.text = timeString;
    }

    public void ClearAlarmTime()
    {
        viewComponents.AlarmInputField.text = "";
    }

    public void StartNewAlarmTime()
    {
        SetAlarmTime(alarmData.AlarmTime);
        viewComponents.AlarmInputField.Select();
    }
}
