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
    private bool _ropeInput;
    public bool RopeInput
    {
        get
        {
            return _ropeInput;
        }
    }
    private bool _tractorBeamActive;
    public bool TractorBeamActive
    {
        get
        {
            return _tractorBeamActive;
        }
    }
    private Vector3 _mousePosition;
    public Vector3 MousePosition
    {
        get
        {
            return _mousePosition;
        }
    }

    public InputState inputState;

    void Update()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _ropeInput = Input.GetButton("Jump");
        if (Input.GetButton("Fire1") || Input.GetButtonDown("Fire2"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hitInfo, LayerMask.GetMask("BackgroundPlane"));
            _mousePosition = hitInfo.point;
        }
        switch (inputState)
        {
            case InputState.Building:
                if (Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject())
                {
                    BuildingManager.Instance.Build(MousePosition);
                }
                if(Input.GetButtonDown("Fire2") && !EventSystem.current.IsPointerOverGameObject())
                {
                    BuildingManager.Instance.DestroyBuilding(MousePosition);
                }
                if (Input.GetButtonDown("BuildingMode"))
                {
                    ChangeInputState(InputState.Playing);
                    TooltipManager.Instance.PurgeList();
                }
                break;
            case InputState.Playing:
                _tractorBeamActive = Input.GetButton("Fire1");
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