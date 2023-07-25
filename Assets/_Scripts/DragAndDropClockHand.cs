using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DragAndDropClockHand : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private ClockHand clockHand;
    [Inject]
    private Alarm alarm;

    private bool isDrag;
    public bool isDragEnabled;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDragEnabled || eventData.button != PointerEventData.InputButton.Left)
        {
            eventData.pointerDrag = null;
            return;
        }

        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDrag && eventData.button == PointerEventData.InputButton.Left)
        {
            LookAtMouse();
            alarm.SetTimeByHandAngle(transform.eulerAngles.z, clockHand);
        }
    }

    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //The angle is counted from the vector.up, because the clock hand always starts its course from the top
        float angle = Vector2.SignedAngle(Vector2.up, mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
    }
}
