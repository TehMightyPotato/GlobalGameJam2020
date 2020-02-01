using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    public EventHandler<InputStateChangedArgs> OnInputStateChanged;
    private Vector2 _movementInput;
    public Vector2 MovementInput
    {
        get
        {
            return _movementInput;
        }
    }

    public InputState inputState;

    void Update()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        switch (inputState)
        {
            case InputState.Building:
                if(Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject())
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Physics.Raycast(ray, out var hitInfo, LayerMask.GetMask("BackgroundPlane"));
                    BuildingManager.Instance.Build(hitInfo.point);
                }
                if (Input.GetButtonDown("BuildingMode"))
                    ChangeInputState(InputState.Playing);
                break;
            case InputState.Playing:

                if (Input.GetButtonDown("BuildingMode"))
                    ChangeInputState(InputState.Building);
                break;
        }
    }

    public void ChangeInputState(InputState state)
    {
        inputState = state;
        InputStateChanged(this);
    }

    public void InputStateChanged(object sender)
    {
        OnInputStateChanged?.Invoke(this, new InputStateChangedArgs(inputState));
    }
}

public enum InputState
{
    Building,
    Playing
}

public class InputStateChangedArgs : EventArgs
{
    public InputState inputState;

    public InputStateChangedArgs(InputState inputState)
    {
        this.inputState = inputState;
    }
}