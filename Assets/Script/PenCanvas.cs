using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DrawLine
{
    public class PenCanvas : MonoBehaviour, IPointerClickHandler
    {
        public Action OnPenCanvasLeftClickEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerId == -1)
            {
                OnPenCanvasLeftClickEvent?.Invoke();
            }
        }
    }
}
