using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dot : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Line line;
    public int index;

    public Action<Dot> OnDragEvent;
    public Action<Dot> OnRightClickEvent;

    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerId == -2)
        {
            OnRightClickEvent?.Invoke(this);
        }
    }

    public void SetLine(Line line)
    {
        this.line = line;
    }
}
