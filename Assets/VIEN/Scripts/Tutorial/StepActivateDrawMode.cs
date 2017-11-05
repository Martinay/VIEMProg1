public class StepActivateDrawMode : TutorialStepBase
{
    public override bool HasFinished { get { return InputBehaviour.CurrentInput.IsDrawingModeGesture; } }
}