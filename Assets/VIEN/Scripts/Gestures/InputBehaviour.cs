using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    public MouseInput MouseInput;
    public GestureInput GestureInput;
    private IInput _currentInput;

    public IInput CurrentInput { get { return _currentInput; } }
    void Start()
    {
        _currentInput = GestureInput;
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
            SwitchInput();

        _currentInput.UpdateInput();
    }

    public Vector2 GetScreenCoordinate()
    {
        return _currentInput.GetScreenCoordinate();
    }

    private void SwitchInput()
    {
        _currentInput.Dispose();

        if (_currentInput is MouseInput)
            _currentInput = GestureInput;
        else
            _currentInput = MouseInput;

        _currentInput.StartInput();
    }
}
