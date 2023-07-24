using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropClockHand : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private RectTransform rectTransform;
    private bool isDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
        {
            eventData.pointerDrag = null;
        }

        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDrag && eventData.button == PointerEventData.InputButton.Left)
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.SignedAngle(Vector2.up, mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
    }
}
