using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GesturesLogic : MonoBehaviour
{
    public GameLogic GameLogic;

    public GameObject DrawingHand;

    private bool _isDrawingMode;
    private bool _isDrawing;

    void Update()
    {
        if (_isDrawing)
            Debug.Log(DrawingHand.transform.position);
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
}
