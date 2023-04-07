using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenTool : MonoBehaviour
{
    [Header("Pen Canvas")]
    [SerializeField] private PenCanvas penCanvas;

    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;

    [Header("Lines")]
    [SerializeField] Transform lineParent;
    [SerializeField] private GameObject linePrefab;
    private Line currentLine;

    private void Start()
    {
        penCanvas.OnPenCanvasLeftClickEvent += AddDot;
    }

    private void AddDot()
    {
        if (currentLine == null)
        {
            currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent)
                .GetComponent<Line>();
        }
        Dot dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent)
            .GetComponent<Dot>();
        dot.OnDragEvent += MoveDot;
        dot.OnRightClickEvent += RemoveDot;
        currentLine.AddPoint(dot);
    }

    private void RemoveDot(Dot dot)
    {
        Line line = dot.line;
        line.SplitPointsAtIndex(dot.index, out List<Dot> before, out List<Dot> after);

        Destroy(line.gameObject);
        Destroy(dot.gameObject);

        Line beforeLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent)
            .GetComponent<Line>();
        for (int i = 0; i < before.Count; i++)
        {
            beforeLine.AddPoint(before[i]);
        } 
        
        Line afterLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent)
            .GetComponent<Line>();
        for (int i = 0; i < after.Count; i++)
        {
            afterLine.AddPoint(after[i]);
        }
    }

    private void MoveDot(Dot dot)
    {
        dot.transform.position = GetMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
