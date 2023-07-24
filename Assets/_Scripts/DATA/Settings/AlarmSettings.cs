using UnityEngine;

[CreateAssetMenu(fileName = "AlarmSettings", menuName = "ScriptableObjects/AlarmSettings")]
public class AlarmSettings : ScriptableObject
{
    public AudioClip Clip;

    public Color colorOfHands;
}

