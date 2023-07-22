using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public class TimeAcquisitionAPI
{
    /* API (json)
    {
      "abbreviation": "MSK",
      "client_ip": "46.22.55.223",
      "datetime": "2023-07-22T10:44:37.104566+03:00",
      "day_of_week": 6,
      "day_of_year": 203,
      "dst": false,
      "dst_from": null,
      "dst_offset": 0,
      "dst_until": null,
      "raw_offset": 10800,
      "timezone": "Europe/Moscow",
      "unixtime": 1690011877,
      "utc_datetime": "2023-07-22T07:44:37.104566+00:00",
      "utc_offset": "+03:00",
      "week_number": 29
    }
    */

    [Inject]
    private InternetSettings settings;

    public IEnumerator GetRealTimeFromAPI(string url, TimeGetterState state)
    {
        state.status = TimeGetterStatus.Started;

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogWarning(
                $"When trying to get the date from the address \"{url}\" an error occurred: \"{unityWebRequest.error}\"!");

            state.status = TimeGetterStatus.Failed;
            yield break;
        }

        FindTime(unityWebRequest.downloadHandler.text, state);
    }

    private void FindTime(string text, TimeGetterState state)
    {
        //"datetime": "2023-07-22T10:44:37.104566+03:00"
        //@"\d{2}:\d{2}:\d{2}"
        Match timeMatch = Regex.Match(text, settings.RegexPattern);

        if (!timeMatch.Success)
        {
            Debug.LogWarning(
                $"The regular expression failed to detect the date in: \n \"{text}\" \nby pattern: \"{settings.RegexPattern}\"!");
            state.status = TimeGetterStatus.Failed;
            return;
        }

        string timeString = timeMatch.Value;
        bool isParseSuccess = DateTime.TryParse(timeString, out DateTime result);

        if (!isParseSuccess)
        {
            Debug.LogWarning(
                $"Failed to try parse the string: \"{timeString}\" in DateTime type!");
            state.status = TimeGetterStatus.Failed;
            return;
        }

        state.status = TimeGetterStatus.Success;
        state.time = result;
    }
}
