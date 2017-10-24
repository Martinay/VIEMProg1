using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseInput : MonoBehaviour, IInputMode
{
    public FirstPersonController FPSController;
    private bool _drawMode;
    private bool _isDrawing;

    public bool IsDrawingGesture { get { return _isDrawing; } }

    public bool IsDrawingModeGesture { get { return _drawMode; } }

    public void Dispose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;        
        FPSController.enabled = true;
    }

    public Vector2 GetScreenCoordinate()
    {
        var mousePosition = Input.mousePosition;
        return new Vector2(mousePosition.x, mousePosition.y);
    }

    public void StartInput()
    {
        FPSController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UpdateInput()
    {
        if (Input.GetKeyDown("d"))
        {
            _drawMode = !_drawMode;
        }
        if(Input.GetMouseButtonDown(0))
        {
            _isDrawing = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
        }
    }
}
