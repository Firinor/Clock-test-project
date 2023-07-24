using System;
using TMPro;
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
    [Inject]
    private AlarmSettings alarmSettings;
    [Inject]
    private ClockViewUtil clockView;

    public void SetAlarmTime(DateTime time)
    {
        string timeString = time.ToString(clockSettings.timeFormat);
        viewComponents.AlarmInputField.text = timeString;
        viewComponents.AlarmImage.color = Color.white;
        viewComponents.AlarmImageGameObject.SetActive(true);
    }

    public void ClearAlarmTime()
    {
        viewComponents.AlarmInputField.text = "";
        viewComponents.AlarmImageGameObject.SetActive(false);
    }

    public void SelectNewAlarmTime()
    {
        SetAlarmTime(alarmData.AlarmTime);
        viewComponents.AlarmImage.color = alarmSettings.colorOfHands;
        viewComponents.AlarmImageGameObject.SetActive(true);
        viewComponents.AlarmInputField.Select();

        clockView.HighlightClockHands(alarmSettings.colorOfHands);
        clockView.SetTimeHands(alarmData.AlarmTime);
    }

    public void OnEndAlarmSelect()
    {
        clockView.HighlightClockHands(clockSettings.colorOfHands);
    }
    public void OnEditAlarm(TMP_InputField input)
    {
        if (DateTime.TryParse(input.text, out DateTime time))
        {
            clockView.SetTimeHands(time);
        }
    }
}
