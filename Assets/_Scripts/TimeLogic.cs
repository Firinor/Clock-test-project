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

    [Inject]
    private TimeGetter timeGetter;

    CompositeDisposable disposables = new CompositeDisposable();

    void Start()
    {
        CheckTime();

        Observable.EveryFixedUpdate()
            .Subscribe(_ => timeData.DeltaTime += Time.fixedDeltaTime)
            .AddTo(disposables);

        Observable.EveryUpdate()
            .Where(_ => timeData.DeltaTime > 1f)
            .Subscribe(_ => NextSecond())
            .AddTo(disposables);
    }

    private void CheckTime()
    {
        timeGetter.CheckTheTime();
    }

    private void NextSecond()
    {
        timeData.DeltaTime -= 1f;
        timeData.currentTime = timeData.currentTime.AddSeconds(1);
        timeView.SetTime(timeData.currentTime);
    }

    private void OnDestroy()
    {
        disposables.Clear();
    }
}
