using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseInput : MonoBehaviour, IInputMode
{
    public FirstPersonController FPSController;
    private bool _drawMode;

    public bool IsDrawingGesture { get { return Input.GetMouseButtonDown(0); } }

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

    public void Start()
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
    }
}
