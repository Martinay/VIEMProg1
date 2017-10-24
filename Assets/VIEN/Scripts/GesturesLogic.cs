using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;
using UnityEngine.UI;

public class GesturesLogic : MonoBehaviour
{
    public GameLogic GameLogic;
    public GameObject LineRenderTarget;
    public RawImage VisualRepresentation;
    public Text DebugText;
    public MouseInput MouseInputModeGameObject;
    public GestureInput GestureInputModeGameObject;

    private IInputMode _currentInputMode;
    private LineRenderer _lineRenderer;
    private RectTransform _visualRepresentationRectTransform;
    private IInputMode _mouseInputMode;
    private IInputMode _gestureInputMode;
    private float _screenScaleFactorWidth;
    private float _screenScaleFactorHeight;
    private Stack<Vector3> _points;
    private bool _isDrawingMode;
    void Start()
    {
        _points = new Stack<Vector3>();
        _lineRenderer = LineRenderTarget.GetComponent<LineRenderer>();
        _visualRepresentationRectTransform = VisualRepresentation.GetComponent<RectTransform>();
        _mouseInputMode = MouseInputModeGameObject.GetComponent<IInputMode>();
        _gestureInputMode = GestureInputModeGameObject.GetComponent<IInputMode>();

        _currentInputMode = _mouseInputMode;

        var visualRepresentationWidth = _visualRepresentationRectTransform.sizeDelta.x;
        var visualRepresentationHeight = _visualRepresentationRectTransform.sizeDelta.y;
        var drawingWidth = _lineRenderer.bounds.size.x;
        var drawingHeight = _lineRenderer.bounds.size.y;
        _screenScaleFactorWidth = drawingWidth / visualRepresentationWidth;
        _screenScaleFactorHeight = drawingHeight / visualRepresentationHeight;
    }

    void Update()
    {
        DebugText.text = _currentInputMode.GetType().Name;
        if (Input.GetKeyDown("i"))
        {
            SwitchInput();
            Reset();
        }

        _currentInputMode.UpdateInput();

        CheckDrawingMode();

        if(!_currentInputMode.IsDrawingGesture || !_currentInputMode.IsDrawingModeGesture)
            return;

        Vector3 positionScreen = _currentInputMode.GetScreenCoordinate();
        var positionLocal = MapScreenToLocal(positionScreen);

        if (_points.Count == 0)
        {
            _points.Push(positionLocal);
            return;
        }

        var distanceToOld = Vector3.Distance(_points.Peek(), positionLocal);
        if (distanceToOld < 0.3)
            return;

        _points.Push(positionLocal);
        DrawNewPoint(positionLocal);
    }

    private void CheckDrawingMode()
    {
        if (_currentInputMode.IsDrawingModeGesture && _isDrawingMode)
            return;

        if (_currentInputMode.IsDrawingModeGesture)
            StartDrawing();
        else
            GameLogic.ExitDrawMode();
    }

    private void StartDrawing()
    {
        Reset();
        GameLogic.EnterDrawMode();
    }

    private void SwitchInput()
    {
        _currentInputMode.Dispose();

        if (_currentInputMode == _mouseInputMode)
            _currentInputMode = _gestureInputMode;
        else
            _currentInputMode = _mouseInputMode;

        _currentInputMode.Start();
    }

    private Vector3 MapScreenToLocal(Vector3 positionScreen)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_visualRepresentationRectTransform, positionScreen, null, out localPoint);
        var mappedVector = new Vector3(localPoint.x * _screenScaleFactorWidth, 0.1f, localPoint.y * _screenScaleFactorHeight);
        Debug.Log(mappedVector + " " + localPoint + " " + positionScreen);
        return mappedVector;
    }

    private void DrawNewPoint(Vector3 position)
    {
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPosition(_points.Count - 1, position);
    }

    private void Reset()
    {
        _points.Clear();
        _lineRenderer.positionCount = 0;
    }
}
