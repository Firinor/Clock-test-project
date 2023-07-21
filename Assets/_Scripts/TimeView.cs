using System;

public class TimeView
{
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

    private void SetClockNumber()
    {
        throw new NotImplementedException();
    }

    private void SetSecondHand()
    {
        throw new NotImplementedException();
    }

    private void SetMinuteHand()
    {
        throw new NotImplementedException();
    }

    private void SetHourHand()
    {
        throw new NotImplementedException();
    }
}
