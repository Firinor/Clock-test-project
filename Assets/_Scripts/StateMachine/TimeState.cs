using Zenject;

class TimeState : IState
{
    [Inject]
    private TimeView timeView;
    [Inject]
    private ClockViewUtil clockView;
    [Inject]
    private ClockSettings clockSettings;

    public void Enter()
    {
        timeView.HandsGoWithTick();
        clockView.SetClockHandsColor(clockSettings.colorOfHands);
    }

    public void Exit()
    {
        timeView.HandsDontGoWithTick();
    }
}