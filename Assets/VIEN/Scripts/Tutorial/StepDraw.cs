public class StepDraw : TutorialStepBase
{
    public override bool HasFinished { get { return InputBehaviour.CurrentInput.IsDrawingModeGesture && InputBehaviour.CurrentInput.IsDrawingGesture; } }
}