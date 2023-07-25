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
    }


    public void ClearAlarmTime()
    {
        viewComponents.AlarmInputField.text = "";
    }
    public void SelectNewAlarmTime()
    {
        SetAlarmTime(alarmData.AlarmTime);
        viewComponents.AlarmInputField.Select();
        clockView.SetTimeHands(alarmData.AlarmTime);
    }
    public void ButtonToSet()
    {
        viewComponents.AlarmButtonText.text = alarmSettings.ButtonSetText;
    }
    public void ButtonToOK()
    {
        viewComponents.AlarmButtonText.text = alarmSettings.ButtonOkText;
    }
    public void OnEditAlarm(TMP_InputField input)
    {
        if (DateTime.TryParse(input.text, out DateTime time))
        {
            clockView.SetTimeHands(time);
        }
    }

    public void CheckAlarmImage()
    {
        if (alarmData.isAlarmEnabled)
            ShowSetColorAlarmImage();
        else
            HideAlarmImage();
    }

    public void ShowEditColorAlarmImage()
    {
        viewComponents.AlarmImageGameObject.SetActive(true);
        viewComponents.AlarmImage.color = alarmSettings.colorOfEditAlarmImage;
    }
    public void ShowSetColorAlarmImage()
    {
        viewComponents.AlarmImageGameObject.SetActive(true);
        viewComponents.AlarmImage.color = alarmSettings.colorOfAlarmImage;
    }
    public void HideAlarmImage()
    {
        viewComponents.AlarmImageGameObject.SetActive(false);
    }
}
