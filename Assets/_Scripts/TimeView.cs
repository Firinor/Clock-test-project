using System;
using UnityEngine;
using Zenject;

public class TimeView
{
    [Inject]
    private ViewComponents viewComponents;

    private DateTime time;

    public void SetTime(DateTime time)
    {
        this.time = time;

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

        viewComponents.HourHand.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void SetMinuteHand()
    {
        int minute = time.Minute;
        float angle = minute * CONSTANTS.HAND_ANGLE_STEP;

        viewComponents.MinuteHand.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void SetSecondHand()
    {
        int second = time.Second;
        float angle = second * CONSTANTS.HAND_ANGLE_STEP;

        viewComponents.SecondHand.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void SetClockNumber()
    {
        viewComponents.ClockText.text = time.ToString("HH:mm:ss");
    }
}
