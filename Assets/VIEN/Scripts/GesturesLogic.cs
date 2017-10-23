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
    private Vector3 _lastPosition;
    private LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = LineRenderTarget.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (!_isDrawing)
            return;
        Vector3 positionScreen = GetHandPositionOnScreen();

        var distanceToOld = Vector3.Distance(_lastPosition, positionScreen);
        if (distanceToOld < 2)
            return;

        _lastPosition = positionScreen;
        DrawNewPoint(positionScreen);
    }

    private Vector3 GetHandPositionOnScreen()
    {
        var hand = DrawingHand.GetLeapHand();
        var position = ((hand.Fingers[0].TipPosition + hand.Fingers[1].TipPosition) * .5f).ToVector3();
        var positionScreen = Camera.main.WorldToScreenPoint(hand.Fingers[0].TipPosition.ToVector3());
        return positionScreen;
    }

    private void DrawNewPoint(Vector3 positionScreen)
    {
        var positionCount = _lineRenderer.positionCount;
        _lineRenderer.SetVertexCount(positionCount ++);
        var random = new System.Random();
        _lineRenderer.SetPosition(_lineRenderer.positionCount, new Vector3(random.Next(5), random.Next(5), 0));
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
        _lastPosition = Vector3.zero;
    }
}
