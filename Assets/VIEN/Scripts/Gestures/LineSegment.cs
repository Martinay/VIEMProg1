using System;
using System.Collections.Generic;
using UnityEngine;

public class LineSegment : IDisposable
{
    private Stack<Vector3> _points;
    private GameObject _lineSegment;
    private LineRenderer _lineRenderer;

    public LineSegment(Transform parent, Material lineMaterial)
    {
        _points = new Stack<Vector3>();

        _lineSegment = new GameObject("lineSegment", typeof(LineRenderer));
        _lineSegment.transform.parent = parent;

        _lineSegment.transform.localPosition = Vector3.zero;

        _lineRenderer = _lineSegment.GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.material = lineMaterial;
        _lineRenderer.positionCount = 0;
        _lineRenderer.useWorldSpace = false;
    }

    public IEnumerable<Vector3> Points
    {
        get
        {
            return _points;
        }
    }

    public bool CheckDistanceToLastPoint(Vector3 newPosition)
    { return _points.Count == 0 || Vector3.Distance(_points.Peek(), newPosition) > 0.3; }

    public void AddAndDrawPoint(Vector3 vector)
    {
        //Debug.Log("Draw: " + vector);
        _points.Push(vector);

        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPosition(_points.Count - 1, vector);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(_lineSegment);
    }
}