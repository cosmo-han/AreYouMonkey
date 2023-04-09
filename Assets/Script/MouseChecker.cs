using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame
{
    public class MouseChecker : InputChecker
    {
        public static MouseChecker Instance;

        private void Awake()
        {
            Instance = this;
        }

        [Header("Pen Canvas")]
        [SerializeField] private PenCanvas penCanvas;

        [Header("Dots")]
        [SerializeField] private GameObject dotPrefab;
        [SerializeField] Transform dotParent;

        private List<GameObject> dots = new();
        public List<GameObject> Dots { get => dots; }

        [Header("Lines")]
        [SerializeField] Transform lineParent;
        [SerializeField] private GameObject linePrefab;

        private Line currentLine;
        public Line CurrentLine { get => currentLine; }


        private int redDot;
        public int RedDot { get => redDot; set => redDot = value; }

        private void Start()
        {
            //AddAddDot();
        }

        public void StopAddDot()
        {
            penCanvas.OnPenCanvasLeftClickEvent -= AddDot;
        }

        public void CanAddDot()
        {
            penCanvas.OnPenCanvasLeftClickEvent += AddDot;
        }

        public void NewDot()
        {
            dots = new();
        }

        private void AddDot()
        {
            if (currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent)
                    .GetComponent<Line>();
            }
            var dotObject = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent);
            dots.Add(dotObject);
            Dot dot = dotObject.GetComponent<Dot>();
            dot.OnDragEvent += MoveDot;
            //dot.OnRightClickEvent += RemoveDot;
            currentLine.AddPoint(dot);
        }

        //public void ClearDot()
        //{
        //    foreach (var obj in dots)
        //    {
        //        RemoveDot(obj.GetComponent<Dot>());
        //    }
        //}

        //private void RemoveDot(Dot dot)
        //{
        //    Line line = dot.line;
        //    line.SplitPointsAtIndex(dot.index, out List<Dot> before, out List<Dot> after);

        //    Destroy(line.gameObject);
        //    Destroy(dot.gameObject);

        //    Line beforeLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent)
        //        .GetComponent<Line>();
        //    for (int i = 0; i < before.Count; i++)
        //    {
        //        beforeLine.AddPoint(before[i]);
        //    }

        //    Line afterLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent)
        //        .GetComponent<Line>();
        //    for (int i = 0; i < after.Count; i++)
        //    {
        //        afterLine.AddPoint(after[i]);
        //    }
        //}

        private void MoveDot(Dot dot)
        {
            dot.transform.position = GetMousePosition();
        }

        public void StopMoveDot(Dot dot)
        {
            dot.OnDragEvent -= MoveDot;
        }

        private Vector3 GetMousePosition()
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMousePosition.z = 0;

            return worldMousePosition;
        }

    }
}