using System;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class TimeView
{
    [Inject]
    private ViewComponents viewComponents;
    [Inject]
    private ClockSettings clockSettings;
    
    private TimeData timeData;
    private DateTime time;

    [Inject]
    public TimeView(TimeData timeData)
    {
        this.timeData = timeData;
        timeData.NextSecond += SetTime;
    }

    private void SetTime()
    {
        time = timeData.currentTime;

        SetHourHand();
        SetMinuteHand();
        SetSecondHand();

        SetClockNumber();
    }
    private void SetHourHand()
    {
        int hour = time.Hour;
        int minute = time.Minute;
        float angle = hour * CONSTANTS.HOUR_ANGLE_STEP + (float)minute * CONSTANTS.MINUTE_ANGLE_RATIO;

        viewComponents.HourHand.DORotate(new Vector3(0f, 0f, angle), clockSettings.timeToTick);
    }

    private void SetMinuteHand()
    {
        int minute = time.Minute;
        float angle = minute * CONSTANTS.HAND_ANGLE_STEP;

        viewComponents.MinuteHand.DORotate(new Vector3(0f, 0f, angle), clockSettings.timeToTick);
    }

    private void SetSecondHand()
    {
        int second = time.Second;
        float angle = second * CONSTANTS.HAND_ANGLE_STEP;

        viewComponents.SecondHand.DORotate(new Vector3(0f, 0f, angle), clockSettings.timeToTick);
    }

    private void SetClockNumber()
    {
        viewComponents.ClockText.text = time.ToString(clockSettings.timeFormat);
    }
}
