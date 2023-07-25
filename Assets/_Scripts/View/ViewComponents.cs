using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewComponents : MonoBehaviour
{
    public RectTransform HourHand;
    public RectTransform MinuteHand;
    public RectTransform SecondHand;

    public TextMeshProUGUI ClockText;

    public Button AlarmButton;
    public TextMeshProUGUI AlarmButtonText;
    public Image AlarmImage;
    public GameObject AlarmImageGameObject;
    public TMP_InputField AlarmInputField;
}