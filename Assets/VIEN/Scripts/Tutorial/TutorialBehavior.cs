using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBehavior : MonoBehaviour
{
	public GameObject GameLogic;
	public DrawingSurfaceBehaviour DrawingSurfaceBehaviour;
    public TutorialStepBase[] TutorialSteps;

    private int _currentStep = 0;

    void OnEnable() {
		TutorialSteps[_currentStep].enabled = true;
		DrawingSurfaceBehaviour.SetOnSubmitHandler(new EmptyOnSubmit());
    }

    // Update is called once per frame
    void Update()
    {
        if (!TutorialSteps[_currentStep].HasFinished)
            return;

		TutorialSteps[_currentStep].enabled = false;
		_currentStep ++;
		print(_currentStep);
		print(TutorialSteps.Length);
		if (_currentStep >= TutorialSteps.Length)
		{
			StartGame();
			return;
		}

		TutorialSteps[_currentStep].enabled = true;
    }

	void StartGame()
	{
		GameLogic.SendMessage("OnTutorialFinished");
	}
}
