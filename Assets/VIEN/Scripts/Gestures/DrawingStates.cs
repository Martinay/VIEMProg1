using System;

public class DrawingStates
{
    private DrawingStateEnum _currentState;
    private readonly GesturesLogic _gesturesLogic;

    public DrawingStates(GesturesLogic gesturesLogic)
    {
        _currentState = DrawingStateEnum.Disabled;
        _gesturesLogic = gesturesLogic;
    }

    public void UpdateState(IInput currentInput)
    {
        switch (_currentState)
        {
            case (DrawingStateEnum.Disabled):
                if (currentInput.IsDrawingModeGesture)
                {
                    _gesturesLogic.ShowDrawingVisual();
                    _currentState = DrawingStateEnum.DrawingVisualEnabled;
                }
                break;
            case (DrawingStateEnum.DrawingVisualEnabled):
                if (!currentInput.IsDrawingModeGesture)
                {
                    _gesturesLogic.HideDrawingVisual();
                    _currentState = DrawingStateEnum.Disabled;
                }
                else if (currentInput.IsDrawingGesture)
                {
                    _gesturesLogic.AddNewLineSegment();
                    _currentState = DrawingStateEnum.Drawing;
                }
                break;
            case (DrawingStateEnum.Drawing):
                if (!currentInput.IsDrawingModeGesture)
                {
                    _gesturesLogic.HideDrawingVisual();
                    _currentState = DrawingStateEnum.Disabled;
                }
                else if (!currentInput.IsDrawingGesture)
                {
                    _currentState = DrawingStateEnum.DrawingVisualEnabled;
                }
                break;
            default:
                throw new Exception("out of range" + _currentState);
        }
    }

    public void DoAction()
    {
        switch (_currentState)
        {
            case (DrawingStateEnum.Disabled):
                break;
            case (DrawingStateEnum.DrawingVisualEnabled):
                break;
            case (DrawingStateEnum.Drawing):
                _gesturesLogic.AddCurrentInputPointToLine();
                break;
            default:
                throw new Exception("out of range" + _currentState);
        }
    }

    enum DrawingStateEnum
    {
        Disabled,
        DrawingVisualEnabled,
        Drawing
    }
}

