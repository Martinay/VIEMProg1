using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leap.Unity;
using UnityEngine;
using UnityEngine.UI;

public class DrawingSurfaceBehaviour : MonoBehaviour
{
    public GameObject DrawingBackground;
    public RawImage VisualRepresentation;
    public Material LineMaterial;
    public InputBehaviour InputBehaviour;
    
    public GameObject DrawingHud;
    public GameObject DrawingSurface;

    private DrawingStates _states;
    private RectTransform _visualRepresentationRectTransform;
    private Renderer _backgroundRenderer;
    private float _screenScaleFactorWidth;
    private float _screenScaleFactorHeight;
    private IList<LineSegment> _lineSegments;
    private LineSegment _currentLineSegment;
    private IOnSubmit _onSubmitHandler;

    public bool IsCurrentLineSegmentEmpty { get { return _currentLineSegment.Points.Count() == 0; } }

    void Start()
    {
        _lineSegments = new List<LineSegment>();
        _visualRepresentationRectTransform = VisualRepresentation.GetComponent<RectTransform>();
        _backgroundRenderer = DrawingBackground.GetComponent<Renderer>();

        _states = new DrawingStates(this);
    }

    void Update()
    {
        _states.UpdateState(InputBehaviour.CurrentInput);

        _states.DoAction();
    }

    void OnDisable()
    {
        DrawingHud.SetActive(false);
    }

    public void SetOnSubmitHandler(IOnSubmit onSubmit)
    {
        _onSubmitHandler = onSubmit;
    }

    public Vector3 GetLocalPoint()
    {
        Vector3 positionScreen = InputBehaviour.GetScreenCoordinate();
        var positionLocal = MapScreenToLocal(positionScreen);
        return positionLocal;
    }

    public bool CheckMinDistanceToLastPoint(Vector3 vectorLocal)
    {
        return _currentLineSegment.CheckDistanceToLastPoint(vectorLocal);
    }

    public bool CheckIfInsideFrame(Vector3 vectorLocal)
    {
        var rect = _backgroundRenderer.bounds.size;
        var maxY = rect.x / 2;
        var maxX = rect.y / 2;

        return Math.Abs(vectorLocal.x) <= maxX && Math.Abs(vectorLocal.y) <= maxY;
    }

    public void AddCurrentInputPointToLine(Vector3 vectorLocal)
    {
        _currentLineSegment.AddAndDrawPoint(vectorLocal);
    }

    public void HideDrawingVisual()
    {
        DrawingHud.SetActive(false);
        DrawingSurface.SetActive(false);
    }
    
    public void OnDrawingFinished()
    {
        _onSubmitHandler.OnSubmit(_lineSegments, (int)_backgroundRenderer.bounds.size.x, (int)_backgroundRenderer.bounds.size.y);
    }    

    public void ShowDrawingVisual()
    {
        Reset();

        DrawingHud.SetActive(true);
        DrawingSurface.SetActive(true);

        var visualRepresentationWidth = Math.Abs(_visualRepresentationRectTransform.rect.width);
        var visualRepresentationHeight = Math.Abs(_visualRepresentationRectTransform.rect.height);
        var drawingWidth = _backgroundRenderer.bounds.size.x;
        var drawingHeight = _backgroundRenderer.bounds.size.y;
        _screenScaleFactorWidth = drawingWidth / visualRepresentationWidth;
        _screenScaleFactorHeight = drawingHeight / visualRepresentationHeight;
    }

    public void AddNewLineSegment()
    {
        _currentLineSegment = new LineSegment(DrawingBackground.transform.parent, LineMaterial);
        _lineSegments.Add(_currentLineSegment);
    }

    private Vector3 MapScreenToLocal(Vector3 positionScreen)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_visualRepresentationRectTransform, positionScreen, null, out localPoint);
        var mappedVector = new Vector3(localPoint.x * _screenScaleFactorWidth, localPoint.y * _screenScaleFactorHeight, 0.1f);
        return mappedVector;
    }

    public void Reset()
    {
        foreach (var lineSegment in _lineSegments)
        {
            lineSegment.Dispose();
        }

        _lineSegments.Clear();
        AddNewLineSegment();
    }
}
