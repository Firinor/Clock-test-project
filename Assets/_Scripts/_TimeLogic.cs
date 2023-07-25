using UniRx;
using UnityEngine;
using Zenject;
using System;

public class TimeLogic : MonoBehaviour
{
    [Inject]
    private TimeData timeData;
    [Inject]
    private StateMachine stateMachine;
    [Inject]
    private TimeState thisState;
    [Inject]
    private TimeView timeView;

    CompositeDisposable disposables = new CompositeDisposable();

    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(1))
            .Repeat()
            .Subscribe(_ => NextSecond())
            .AddTo(disposables);

        timeView.TableGoWithTick();

        stateMachine.SetState(thisState);
    }

    private void NextSecond()
    {
        timeData.CurrentTime = timeData.CurrentTime.AddSeconds(1);
    }

    private void OnDestroy()
    {
        disposables.Clear();
    }
}
