using System;
using Leap.Unity;
using UnityEngine;

public class GestureInput : MonoBehaviour, IInput
{
    public IHandModel DrawingHand;
    private bool _fingerExtended;
    private bool _fingerPinched;

    public bool IsDrawingGesture { get { return _fingerPinched; } }

    public bool IsDrawingModeGesture { get { return _fingerExtended; } }

    public bool IsSubmitGesture { get { return false; } }

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

    public void OnPinchActivate()
    {
        _fingerPinched = true;
    }

    public void OnPinchDeactivate()
    {
        _fingerPinched = false;
    }

    public void OnFingerExtendActivate()
    {
        _fingerExtended = true;
    }

    public void OnFingerExtendDeactivate()
    {
        _fingerExtended = false;
    }

    public void UpdateInput()
    {
    }

    public void StartInput()
    {
    }
}
