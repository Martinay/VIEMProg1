using System;
using UnityEngine;

public interface IInput : IDisposable
{
    bool IsDrawingGesture { get; }
    bool IsDrawingModeGesture { get; }
    bool IsSubmitGesture { get; }
    
    void UpdateInput();    
    Vector2 GetScreenCoordinate();
    void StartInput();
}

