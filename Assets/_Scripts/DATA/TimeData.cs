using System;

public class TimeData
{
    public float DeltaTime;
    public DateTime currentTime;

    public event Action NextSecond;

    public void NextSecondInvoke()
    {
        NextSecond?.Invoke();
    }
}
