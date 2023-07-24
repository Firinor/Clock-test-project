using System;

public class TimeData
{
    private DateTime currentTime;
    public DateTime CurrentTime 
    {
        get
        { 
            return currentTime;
        }
        set
        {
            currentTime = value;
            NewTimeEvent?.Invoke();
        }
    }

    public event Action NewTimeEvent;
}
