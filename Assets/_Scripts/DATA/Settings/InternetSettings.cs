using UnityEngine;

[CreateAssetMenu(fileName = "InternetSettings", menuName = "ScriptableObjects/InternetSettings")]
public class InternetSettings : ScriptableObject
{
    public string[] Addresses;

    //HelpURL("https://regex101.com/")
    [Tooltip("Example of a search string:" +
        "\n\"datetime\": \"2023-07-22T10:44:37.104566+03:00\" " +
        "\n HelpURL https://regex101.com/ ")]
    public string RegexPattern;
}
