public class StepSubmit : TutorialStepBase
{
    public override bool HasFinished { get { return InputBehaviour.CurrentInput.IsDrawingModeGesture && InputBehaviour.CurrentInput.IsSubmitGesture; } }
}