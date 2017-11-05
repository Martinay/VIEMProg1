using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leap.Unity;
using UnityEngine;
using UnityEngine.UI;

public class GesturesLogic : MonoBehaviour
{
    public GameLogic GameLogic;
    public GameObject DrawingBackground;
    public RawImage VisualRepresentation;
    public MouseInput MouseInputModeGameObject;
    public GestureInput GestureInputModeGameObject;
    public Material LineMaterial;

    private IInput _currentInput;
    private DrawingStates _states;
    private RectTransform _visualRepresentationRectTransform;
    private IInput _mouseInput;
    private IInput _gestureInput;
    private Renderer _backgroundRenderer;
    private float _screenScaleFactorWidth;
    private float _screenScaleFactorHeight;
    private IList<LineSegment> _lineSegments;
    private LineSegment _currentLineSegment;

    public bool IsCurrentLineSegmentEmpty { get { return _currentLineSegment.Points.Count() == 0; } }

    void Start()
    {
        _lineSegments = new List<LineSegment>();
        _visualRepresentationRectTransform = VisualRepresentation.GetComponent<RectTransform>();
        _mouseInput = MouseInputModeGameObject.GetComponent<IInput>();
        _gestureInput = GestureInputModeGameObject.GetComponent<IInput>();
        _backgroundRenderer = DrawingBackground.GetComponent<Renderer>();

        _currentInput = _gestureInput;

        _states = new DrawingStates(this);
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
            SwitchInput();

        _currentInput.UpdateInput();

        _states.UpdateState(_currentInput);

        _states.DoAction();
    }

    public Vector3 GetLocalPoint()
    {
        Vector3 positionScreen = _currentInput.GetScreenCoordinate();
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
        GameLogic.ExitDrawMode();
    }

    public void Submit()
    {
        var lines = _lineSegments.Where(x=> !x.IsEmpty).Select(x => new RawCoordinates(x.Points)).ToList();

        GameLogic.SubmitCoordinates(lines, (int)_backgroundRenderer.bounds.size.x, (int)_backgroundRenderer.bounds.size.y);
    }

    public void ShowDrawingVisual()
    {
        Reset();
        GameLogic.EnterDrawMode();

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

    private void SwitchInput()
    {
        _currentInput.Dispose();

        if (_currentInput == _mouseInput)
            _currentInput = _gestureInput;
        else
            _currentInput = _mouseInput;

        _currentInput.StartInput();
    }

    private Vector3 MapScreenToLocal(Vector3 positionScreen)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_visualRepresentationRectTransform, positionScreen, null, out localPoint);
        var mappedVector = new Vector3(localPoint.x * _screenScaleFactorWidth, localPoint.y * _screenScaleFactorHeight, 0.1f);
        return mappedVector;
    }

    private void Reset()
    {
        foreach (var lineSegment in _lineSegments)
        {
            lineSegment.Dispose();
        }

        _lineSegments.Clear();
        AddNewLineSegment();
    }
}
