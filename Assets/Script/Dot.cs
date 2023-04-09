using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MonkeyGame
{
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
            if (eventData.pointerId == -2)
            {
                OnRightClickEvent?.Invoke(this);
            }
        }

        public void SetLine(Line line)
        {
            this.line = line;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Image>().color != Color.red)
            {
                col.GetComponent<Image>().color = Color.red;
                transform.position = new Vector3(col.transform.position.x, col.transform.position.y, transform.position.z);
                transform.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                MouseChecker.Instance.StopMoveDot(GetComponent<Dot>());
                MouseChecker.Instance.RedDot++;
            }
        }
    }
}
