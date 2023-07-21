using System;
using UniRx;
using UnityEngine;
using Zenject;

public class TimeLogic : MonoBehaviour
{
    [Inject]
    private TimeView timeView;

    [Inject]
    private TimeData timeData;

    CompositeDisposable disposables = new CompositeDisposable();

    void Start()
    {
        timeData.currentTime = GetTime();

        Observable.EveryFixedUpdate()
            .Subscribe(_ => timeData.DeltaTime += Time.fixedDeltaTime)
            .AddTo(disposables);

        Observable.EveryUpdate()
            .Where(_ => timeData.DeltaTime > 1f)
            .Subscribe(_ => NextSecond())
            .AddTo(disposables);
    }

    private DateTime GetTime()
    {
        return DateTime.Now;
    }

    private void NextSecond()
    {
        Debug.Log(timeData.currentTime);

        timeData.DeltaTime -= 1f;
        timeData.currentTime = timeData.currentTime.AddSeconds(1);
        timeView.SetTime(timeData.currentTime);
    }

    private void OnDestroy()
    {
        disposables.Clear();
    }
}
