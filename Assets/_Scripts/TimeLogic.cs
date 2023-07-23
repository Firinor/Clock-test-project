using UniRx;
using UnityEngine;
using Zenject;

public class TimeLogic : MonoBehaviour
{
    [Inject]
    private TimeData timeData;

    CompositeDisposable disposables = new CompositeDisposable();

    void Start()
    {
        Observable.EveryFixedUpdate()
            .Subscribe(_ => timeData.DeltaTime += Time.fixedDeltaTime)
            .AddTo(disposables);

        Observable.EveryUpdate()
            .Where(_ => timeData.DeltaTime > 1f)
            .Subscribe(_ => NextSecond())
            .AddTo(disposables);
    }

    private void NextSecond()
    {
        timeData.DeltaTime -= 1f;
        timeData.currentTime = timeData.currentTime.AddSeconds(1);
        timeData.NextSecondInvoke();
    }

    private void OnDestroy()
    {
        disposables.Clear();
    }
}
