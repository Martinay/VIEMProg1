using System;
using UnityEngine;

public class DrawingStates
{
    private DrawingStateEnum _currentState;
    private readonly DrawingSurfaceBehaviour _gesturesLogic;
    private bool _oneTimeActionExecuted;

    public DrawingStates(DrawingSurfaceBehaviour gesturesLogic)
    {
        _currentState = DrawingStateEnum.Disabled;
        _gesturesLogic = gesturesLogic;
    }

    public void UpdateState(IInput currentInput)
    {
        var lastState = _currentState;

        switch (_currentState)
        {
            case (DrawingStateEnum.Disabled):
                if (currentInput.IsDrawingModeGesture)
                {
                    _currentState = DrawingStateEnum.StartDrawingVisual;
                }
                break;
            case (DrawingStateEnum.StartDrawingVisual):
            case (DrawingStateEnum.DrawingVisualEnabled):
                if (!currentInput.IsDrawingModeGesture)
                {
                    _currentState = DrawingStateEnum.Disabled;
                }
                else if (currentInput.IsDrawingGesture)
                {
                    _currentState = DrawingStateEnum.Drawing;
                }
                else if (currentInput.IsSubmitGesture)
                {
                    _currentState = DrawingStateEnum.Submit;
                }
                break;
            case (DrawingStateEnum.Drawing):
                if (!currentInput.IsDrawingModeGesture)
                {
                    _currentState = DrawingStateEnum.Disabled;
                }
                else if (!currentInput.IsDrawingGesture)
                {
                    _currentState = DrawingStateEnum.DrawingVisualEnabled;
                }
                break;
            case (DrawingStateEnum.Submit):
                if (!currentInput.IsDrawingModeGesture)
                {
                    _currentState = DrawingStateEnum.Disabled;
                }
                if (!currentInput.IsSubmitGesture)
                {
                    _currentState = DrawingStateEnum.StartDrawingVisual;
                }
                break;
            default:
                throw new Exception("out of range" + _currentState);
        }

        if (_currentState != lastState)
            _oneTimeActionExecuted = false;
    }

    public void DoAction()
    {
        switch (_currentState)
        {
            case (DrawingStateEnum.Disabled):
                ExecuteOneTimeAction(() => _gesturesLogic.HideDrawingVisual());
                break;
            case (DrawingStateEnum.StartDrawingVisual):
                ExecuteOneTimeAction(() => _gesturesLogic.ShowDrawingVisual());
                break;
            case (DrawingStateEnum.DrawingVisualEnabled):
                break;
            case (DrawingStateEnum.Drawing):
                ExecuteOneTimeAction(() => _gesturesLogic.AddNewLineSegment());
                var localVector = _gesturesLogic.GetLocalPoint();
                if(!_gesturesLogic.CheckIfInsideFrame(localVector))
                {
                    if(!_gesturesLogic.IsCurrentLineSegmentEmpty)
                        _gesturesLogic.AddNewLineSegment();
                    break;
                }
                if(!_gesturesLogic.CheckMinDistanceToLastPoint(localVector))
                    break;
                _gesturesLogic.AddCurrentInputPointToLine(localVector);
                break;
            case (DrawingStateEnum.Submit):
                ExecuteOneTimeAction(() => _gesturesLogic.OnDrawingFinished());
                break;
            default:
                throw new Exception("out of range" + _currentState);
        }
    }

    private void ExecuteOneTimeAction(Action action)
    {
        if (!_oneTimeActionExecuted)
        {
            action();
            _oneTimeActionExecuted = true;
        }
    }

    enum DrawingStateEnum
    {
        Disabled,
        StartDrawingVisual,
        DrawingVisualEnabled,
        Drawing,
        Submit
    }
}

