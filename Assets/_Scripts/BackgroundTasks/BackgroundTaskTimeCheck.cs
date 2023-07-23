using System.Collections;
using UnityEngine;
using Zenject;

public class BackgroundTaskTimeCheck : MonoBehaviour
{
    [Inject]
    private TimeGetter timeGetter;
    [Inject]
    private BackgroundTaskSettings settings;

    private void Start()
    {
        StartCoroutine(CheckTheTime());
    }

    public IEnumerator CheckTheTime()
    {
        while(enabled)
        {
            yield return timeGetter.GetTime();
            yield return new WaitForSeconds(settings.SecondsBetweenChecks);
        }
    }
}
