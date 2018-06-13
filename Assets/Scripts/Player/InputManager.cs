﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [ReadOnly]
    public InputsContainer inputsContainer;

	void Start () {
        inputsContainer = new InputsContainer();
	}
	
	void Update () {
        inputsContainer.ClearInputs();
        CheckInputs();
	}

    

    private void CheckInputs()
    {
        inputsContainer.HorizontalMovementInput = Input.GetAxisRaw(Constants.Inputs.Horizontal);
        inputsContainer.VerticalMovementInput = Input.GetAxisRaw(Constants.Inputs.Vertical);
        inputsContainer.attackPressed = Input.GetButtonDown(Constants.Inputs.Attack);
        inputsContainer.evadePressed = Input.GetButtonDown(Constants.Inputs.Evade);
        inputsContainer.lockOnPressed = Input.GetButtonDown(Constants.Inputs.LockOn);
        inputsContainer.interactPressed = Input.GetButtonDown(Constants.Inputs.Interact);
        inputsContainer.inventoryPressed = Input.GetButtonDown(Constants.Inputs.Inventory);
    }
}
