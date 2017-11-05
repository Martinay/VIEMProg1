﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBehavior : MonoBehaviour
{
    public TutorialStepBase[] TutorialSteps;

    private int _currentStep = 0;

	void OnStart()
	{
		OnEnable();
	}

    void OnEnable() {
		TutorialSteps[_currentStep].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TutorialSteps[_currentStep].HasFinished)
            return;

		TutorialSteps[_currentStep].enabled = false;
		_currentStep ++;
		
		if (_currentStep >= TutorialSteps.Length)
		{
			StartGame();
			return;
		}

		TutorialSteps[_currentStep].enabled = true;
    }

	void StartGame()
	{
        gameObject.SetActive(false);
	}
}
