using UnityEngine;

[CreateAssetMenu(fileName = "ClockSettings", menuName = "ScriptableObjects/ClockSettings")]
public class ClockSettings : ScriptableObject
{
    public float timeToTick;
    public string timeFormat;

    public Color colorOfHands;
}

