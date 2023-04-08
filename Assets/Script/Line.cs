using System.Collections.Generic;
using UnityEngine;
using MonkeyGame;

namespace DrawLine
{
    public class Line : MonoBehaviour
    {
        private LineRenderer line;
        private List<Dot> dots;

        private void Awake()
        {
            line = GetComponent<LineRenderer>();
            line.positionCount = 0;

            dots = new List<Dot>();
        }

        public void AddPoint(Dot dot)
        {
            dot.index = dots.Count;
            dot.SetLine(this);

            line.positionCount++;
            dots.Add(dot);
            if (dots.Count == RoundSetter.Instance.GetMouseCorrect().Count)
            {
                line.loop = enabled;
                PenTool.Instance.RemoveAddDot();
            }
        }

        public void SplitPointsAtIndex(int index, out List<Dot> beforeDots, out List<Dot> afterDots)
        {
            List<Dot> before = new List<Dot>();
            List<Dot> after = new List<Dot>();

            int i = 0;
            for (; i < index; i++)
            {
                before.Add(dots[i]);
            }
            i++;
            for (; i < dots.Count; i++)
            {
                after.Add(dots[i]);
            }

            beforeDots = before;
            afterDots = after;
        }

        private void LateUpdate()
        {
            if (dots.Count >= 2)
            {
                for (int i = 0; i < dots.Count; i++)
                {
                    line.SetPosition(i, dots[i].transform.position);
                }
            }
        }
    }
}
