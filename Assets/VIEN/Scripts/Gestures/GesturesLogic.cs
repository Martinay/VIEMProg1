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
        DebugText.text = _currentInput.GetType().Name;
        if (Input.GetKeyDown("i"))
            SwitchInput();

        _currentInput.UpdateInput();

        _states.UpdateState(_currentInput);

        _states.DoAction();
    }

    public void AddCurrentInputPointToLine()
    {
        Vector3 positionScreen = _currentInput.GetScreenCoordinate();
        var positionLocal = MapScreenToLocal(positionScreen);

        if (!_currentLineSegment.CanDraw(positionLocal))
            return;

        _currentLineSegment.AddAndDrawPoint(positionLocal);
    }

    public void HideDrawingVisual()
    {
        GameLogic.ExitDrawMode();
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
