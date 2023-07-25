using System;
using Zenject;

public class TimeView
{
    [Inject]
    private ViewComponents viewComponents;
    [Inject]
    private ClockSettings clockSettings;
    [Inject]
    private ClockViewUtil clockView;
    [Inject]
    private TimeData timeData;
    private bool isUpdated = false;

    public void HandsDontGoWithTick()
    {
        timeData.NewTimeEvent -= SetClockHands;
        isUpdated = false;
    }
    public void HandsGoWithTick()
    {
        if (isUpdated)
            return;

        timeData.NewTimeEvent += SetClockHands;
        isUpdated = true;
    }
    public void TableGoWithTick()
    {
        timeData.NewTimeEvent += SetClockNumber;
    }

    private void SetClockHands()
    {
        clockView.SetTimeHands(timeData.CurrentTime);
    }
    private void SetClockNumber()
    {
        viewComponents.ClockText.text = timeData.CurrentTime.ToString(clockSettings.timeFormat);
    }
}
