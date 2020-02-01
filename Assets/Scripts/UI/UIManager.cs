using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject buildingMenu;
    public UIBuildingMenuContentLoader uiContentLoader;

    private void Start()
    {
        uiContentLoader.Init();
        InputManager.Instance.OnInputStateChanged += OnInputStateChanged;
    }

    public void OnInputStateChanged(object sender, InputStateChangedArgs args)
    {
        if(args.inputState == InputState.Building)
        {
            buildingMenu.SetActive(true);
        }
        else
        {
            buildingMenu.SetActive(false);
        }
    }
}
