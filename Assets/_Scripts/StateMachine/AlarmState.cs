using UnityEngine;
using Zenject;

public class AlarmState : IState
{
    [Inject]
    private AlarmView alarmView;
    [Inject]
    private ViewComponents viewComponents;
    [Inject]
    private ClockViewUtil clockView;
    [Inject]
    private AlarmSettings alarmSettings;

    public void Enter()
    {
        clockView.SetClockHandsColor(alarmSettings.colorOfHands);
        
        alarmView.SelectNewAlarmTime();
        alarmView.ButtonToOK();
        alarmView.ShowEditColorAlarmImage();
        SetEnableDragAndDrop(true);
    }

    private void SetEnableDragAndDrop(bool v)
    {
        EnableDragAndDropForHand(viewComponents.HourHand, v);
        EnableDragAndDropForHand(viewComponents.MinuteHand, v);
        EnableDragAndDropForHand(viewComponents.SecondHand, v);
    }

    private void EnableDragAndDropForHand(RectTransform hourHand, bool v)
    {
        if (hourHand.TryGetComponent(out DragAndDropClockHand hand))
            hand.isDragEnabled = v;
    }

    public void Exit()
    {
        alarmView.ButtonToSet();
        alarmView.CheckAlarmImage();
        SetEnableDragAndDrop(false);
    }
}