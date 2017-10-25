using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;
using UnityEngine.UI;

public class GesturesLogic : MonoBehaviour
{
    public GameLogic GameLogic;
    public GameObject DrawingBackground;
    public RawImage VisualRepresentation;
    public Text DebugText;
    public MouseInput MouseInputModeGameObject;
    public GestureInput GestureInputModeGameObject;
    public Material LineMaterial;

    private IInputMode _currentInputMode;
    private RectTransform _visualRepresentationRectTransform;
    private IInputMode _mouseInputMode;
    private IInputMode _gestureInputMode;
    private Renderer _backgroundRenderer;
    private float _screenScaleFactorWidth;
    private float _screenScaleFactorHeight;
    private IList<LineSegment> _lineSegments;
    private LineSegment _currentLineSegment;
    private DrawingState _currentState;

    void Start()
    {
        _lineSegments = new List<LineSegment>();
        _visualRepresentationRectTransform = VisualRepresentation.GetComponent<RectTransform>();
        _mouseInputMode = MouseInputModeGameObject.GetComponent<IInputMode>();
        _gestureInputMode = GestureInputModeGameObject.GetComponent<IInputMode>();
        _backgroundRenderer = DrawingBackground.GetComponent<Renderer>();

        _currentInputMode = _gestureInputMode;
        _currentState = DrawingState.Disabled;
    }

    void Update()
    {
        DebugText.text = _currentInputMode.GetType().Name;
        if (Input.GetKeyDown("i"))
            SwitchInput();

        _currentInputMode.UpdateInput();

        UpdateState();

        if (_currentState != DrawingState.Drawing)
            return;

        Vector3 positionScreen = _currentInputMode.GetScreenCoordinate();
        var positionLocal = MapScreenToLocal(positionScreen);

        if (!_currentLineSegment.CanDraw(positionLocal))
            return;

        _currentLineSegment.AddAndDrawPoint(positionLocal);
    }

    private void UpdateState()
    {
        switch (_currentState)
        {
            case (DrawingState.Disabled):
                if (_currentInputMode.IsDrawingModeGesture)
                {
                    ShowDrawingVisual();
                    _currentState = DrawingState.DrawingVisualEnabled;
                }
                break;
            case (DrawingState.DrawingVisualEnabled):
                if (!_currentInputMode.IsDrawingModeGesture)
                {
                    HideDrawingVisual();
                    _currentState = DrawingState.Disabled;
                }
                else if (_currentInputMode.IsDrawingGesture)
                {
                    AddNewLineSegment();
                    _currentState = DrawingState.Drawing;
                }
                break;
            case (DrawingState.Drawing):
                if (!_currentInputMode.IsDrawingModeGesture)
                {
                    HideDrawingVisual();
                    _currentState = DrawingState.Disabled;
                }
                else if (!_currentInputMode.IsDrawingGesture)
                {
                    _currentState = DrawingState.DrawingVisualEnabled;
                }
                break;
            default:
                throw new Exception("out of range" + _currentState);
        }
    }

    private void HideDrawingVisual()
    {
        GameLogic.ExitDrawMode();
    }

    private void ShowDrawingVisual()
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

    private void SwitchInput()
    {
        _currentInputMode.Dispose();

        if (_currentInputMode == _mouseInputMode)
            _currentInputMode = _gestureInputMode;
        else
            _currentInputMode = _mouseInputMode;

        _currentInputMode.StartInput();
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

    private void AddNewLineSegment()
    {
        _currentLineSegment = new LineSegment(DrawingBackground.transform.parent, LineMaterial);
        _lineSegments.Add(_currentLineSegment);
    }

    enum DrawingState
    {
        Disabled,
        DrawingVisualEnabled,
        Drawing
    }
}
