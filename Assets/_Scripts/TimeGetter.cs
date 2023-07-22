using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class TimeGetter : MonoBehaviour
{
    [Inject]
    private TimeAcquisitionAPI timeAcquisitionAPI;
    [Inject]
    private TimeData timeData;
    [Inject]
    private InternetSettings settings;

    public IEnumerable CheckTheTime()
    {
        TimeGetterState state = new TimeGetterState();
        for(int i = 0; i < settings.Addresses.Length; i++)
        {
            string adress = settings.Addresses[i];
            if(!string.IsNullOrEmpty(adress))
                yield return timeAcquisitionAPI.GetRealTimeFromAPI(adress, state);

            if(state.status == TimeGetterStatus.Success)
            {
                timeData.currentTime = state.time;
                yield break;
            }
        }

        timeData.currentTime = DateTime.Now;
    }
}
