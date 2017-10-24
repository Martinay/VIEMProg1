using System;
using UnityEngine;

public interface IInputMode : IDisposable
{
    bool IsDrawingGesture { get; }
    bool IsDrawingModeGesture { get; }
    
    void UpdateInput();    
    Vector2 GetScreenCoordinate();
    void StartInput();
}
