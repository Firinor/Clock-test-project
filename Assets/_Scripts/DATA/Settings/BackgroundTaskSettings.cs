using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundTaskSettings", menuName = "ScriptableObjects/BackgroundTaskSettings")]
public class BackgroundTaskSettings : ScriptableObject
{
    public int SecondsBetweenChecks;
}
