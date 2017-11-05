public class StepStartGame : TutorialStepBase
{
    public override bool HasFinished { get { return !_audioSource.isPlaying; } }
}