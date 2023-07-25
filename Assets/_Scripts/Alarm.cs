using System;
using TMPro;
using UnityEngine;
using Zenject;

public class Alarm : MonoBehaviour
{
    [Inject]
    private AlarmData alarmData;
    [Inject]
    private AlarmView alarmView;
    [Inject]
    private BackgroundTaskAlarm backgroundTaskAlarm;
    [Inject]
    private StateMachine stateMachine;
    [Inject]
    private AlarmState thisState;
    private object trow;

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
    public void OnEditAlarm(TMP_InputField input)
    {
        alarmView.OnEditAlarm(input);
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
    public void ButtonOnClick()
    {
        if(stateMachine.currentState != thisState)
            stateMachine.SetState(thisState);
        else
        {

            stateMachine.ReturnPreviousState();
        }
    }
    public void InpitOnSelect()
    {
        if (stateMachine.currentState != thisState)
            stateMachine.SetState(thisState);
    }

    public void SetTimeByHandAngle(float angle, ClockHand clockHand)
    {
        int hour, minute, second = 0;
        DateTime result;

        angle = 360f - angle;

        switch (clockHand)
        {
            case ClockHand.Hour:
                hour = (int)Math.Floor(angle / Math.Abs((float)CONSTANTS.HOUR_ANGLE_STEP));
                result = new DateTime(year: 1, month: 1, day: 1, 
                    hour, alarmData.AlarmTime.Minute, alarmData.AlarmTime.Second);
                break;
            case ClockHand.Minute:
                minute = (int)Math.Floor(angle / Math.Abs((float)CONSTANTS.HAND_ANGLE_STEP));
                result = new DateTime(year: 1, month: 1, day: 1,
                    alarmData.AlarmTime.Hour, minute, alarmData.AlarmTime.Second);
                break;
            case ClockHand.Second:
                second = (int)Math.Floor(angle / Math.Abs((float)CONSTANTS.HAND_ANGLE_STEP));
                result = new DateTime(year: 1, month: 1, day: 1,
                     alarmData.AlarmTime.Hour, alarmData.AlarmTime.Minute, second);
                break;
            default:
                throw new Exception("Unknown type of ÑlockHand!");
        }

        SetAlarm(result);
    }
}
