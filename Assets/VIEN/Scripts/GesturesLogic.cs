using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;

public class GesturesLogic : MonoBehaviour
{
    public GameLogic GameLogic;
    public GameObject LineRenderTarget;

    public IHandModel DrawingHand;

    private bool _isDrawingMode;
    private bool _isDrawing;
    private LineRenderer _lineRenderer;
    private int _screenWidth;
    private int _screenHeight;
    private float _drawingWidth;
    private float _drawingHeight;
    private float _screenScaleFactorWidth;
    private float _screenScaleFactorHeight;
    private Stack<Vector3> _points;
    void Start()
    {
        _points = new Stack<Vector3>();
        _lineRenderer = LineRenderTarget.GetComponent<LineRenderer>();
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _drawingWidth = _lineRenderer.bounds.size.x;
        _drawingHeight = _lineRenderer.bounds.size.y;
        _screenScaleFactorWidth = _drawingWidth / _screenWidth;
        _screenScaleFactorHeight = _drawingHeight / _screenHeight;
    }

    void Update()
    {
        if (!_isDrawing)
            return;
        
        Vector3 positionScreen = GetHandPositionOnScreen();
        var positionLocal = MapScreenToLocal(positionScreen);
        if(_points.Count == 0){
            _points.Push(positionLocal);
            return;
        }

        var distanceToOld = Vector3.Distance(_points.Peek(), positionLocal);
        if (distanceToOld < 0.2)
            return;

        _points.Push(positionLocal);
        DrawNewPoint(positionLocal);
    }

    private Vector3 MapScreenToLocal(Vector3 positionScreen)
    {
        var scaledX = positionScreen.x * _screenScaleFactorWidth;
        var scaledY = positionScreen.y * _screenScaleFactorHeight;
        var centeredX = scaledX - (_drawingWidth / 2);
        var centeredY = scaledY - (_drawingHeight /2);
        var mappedVector = new Vector3(centeredX, 0, centeredY);
        Debug.Log(mappedVector + " " + positionScreen);
        return mappedVector;
    }

    private Vector3 GetHandPositionOnScreen()
    {
        var hand = DrawingHand.GetLeapHand();
        var position = ((hand.Fingers[0].TipPosition + hand.Fingers[1].TipPosition) * .5f).ToVector3();
        var positionScreen = Camera.main.WorldToScreenPoint(hand.Fingers[0].TipPosition.ToVector3());
        return positionScreen;
    }

    private void DrawNewPoint(Vector3 position)
    {
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPositions(_points.ToArray());
        //_lineRenderer.positionCount = 2;
        //_lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        //_lineRenderer.SetPosition(1, new Vector3(5, 5, 0));
        //var random = new System.Random();
        // _lineRenderer.SetPosition(_lineRenderer.positionCount, new Vector3(random.Next(5), random.Next(5), 0));
    }

    public void OnPinchActivate()
    {
        if (!_isDrawingMode)
            return;

        _isDrawing = true;
    }

    public void OnPinchDeactivate()
    {
        if (!_isDrawingMode)
            return;

        _isDrawing = false;
    }

    public void OnFingerExtendActivate()
    {
        Init();
        if (_isDrawingMode)
            return;

        _isDrawingMode = true;
        GameLogic.EnterDrawMode();
    }

    public void OnFingerExtendDeactivate()
    {
        if (!_isDrawingMode)
            return;

        _isDrawingMode = false;
        GameLogic.ExitDrawMode();
    }

    private void Init()
    {
        _lineRenderer.positionCount = 0;
    }
}
