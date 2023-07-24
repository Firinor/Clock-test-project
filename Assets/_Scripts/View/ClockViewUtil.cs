using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClockViewUtil
{
    [Inject]
    private ViewComponents viewComponents;
    [Inject]
    private ClockSettings clockSettings;

    private DateTime time;

    public void SetTimeHands(DateTime time)
    {
        this.time = time;

        SetHourHand();
        SetMinuteHand();
        SetSecondHand();
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

    public void HighlightClockHands(Color color)
    {

        HighlightClockHand(viewComponents.HourHand, color);
        HighlightClockHand(viewComponents.MinuteHand, color);
        HighlightClockHand(viewComponents.SecondHand, color);
    }

    private void HighlightClockHand(RectTransform hand, Color color)
    {
        if (hand.TryGetComponent(out Image image))
            image.color = color;
    }
}
