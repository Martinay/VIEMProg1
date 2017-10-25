using System;
using Leap.Unity;
using UnityEngine;

public class GestureInput : MonoBehaviour, IInput
{
    public IHandModel DrawingHand;
    private bool _menuFingerExtended;
    private bool _menuFingerPinched;
    private bool _drawFingerPinched;

    public bool IsDrawingGesture { get { return _drawFingerPinched; } }

    public bool IsDrawingModeGesture { get { return _menuFingerExtended; } }

    public bool IsSubmitGesture { get { return _menuFingerPinched; } }

    public void Dispose()
    {
    }

    public Vector2 GetScreenCoordinate()
    {
        var hand = DrawingHand.GetLeapHand();
        var position = ((hand.Fingers[0].TipPosition + hand.Fingers[1].TipPosition) * .5f).ToVector3();
        var positionScreen = Camera.main.WorldToScreenPoint(position);
        return positionScreen;
    }

    public void OnDrawPinchActivate()
    {
        _drawFingerPinched = true;
    }

    public void OnDrawPinchDeactivate()
    {
        _drawFingerPinched = false;
    }

    public void OnMenuPinchActivate()
    {
        _menuFingerPinched = true;
    }

    public void OnMenuPinchDeactivate()
    {
        _menuFingerPinched = false;
    }

    public void OnMenuFingerExtendActivate()
    {
        _menuFingerExtended = true;
    }

    public void OnMenuFingerExtendDeactivate()
    {
        _menuFingerExtended = false;
    }

    public void UpdateInput()
    {
    }

    public void StartInput()
    {
    }
}
