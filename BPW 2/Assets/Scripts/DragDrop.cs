using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    //variables
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector3 startLocation = Vector3.zero;

    //Functions
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startLocation = rectTransform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvasGroup.blocksRaycasts = true;
        if (GameObject.FindGameObjectWithTag("Hour") != null && rectTransform.localPosition == GameObject.FindGameObjectWithTag("Hour").GetComponent<RectTransform>().localPosition)
        {
            Debug.Log("Dropped onto an object with the tag 'Hour'.");
        }
        else
        {
            rectTransform.localPosition = startLocation;
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
