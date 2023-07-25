using UnityEngine;

[CreateAssetMenu(fileName = "AlarmSettings", menuName = "ScriptableObjects/AlarmSettings")]
public class AlarmSettings : ScriptableObject
{
    public AudioClip Clip;

    public Color colorOfHands;
    public Color colorOfEditAlarmImage;
    public Color colorOfAlarmImage;

    public string ButtonSetText;
    public string ButtonOkText;
}

