using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingMenuButtonLoader : MonoBehaviour
{
    public BasicBuilding buildingBlueprint;
    public Image buttonImage;
    public Button button;

    public void Init(BasicBuilding building)
    {
        buildingBlueprint = building;
        buttonImage.sprite = building.buildingIcon;
        PartManager.Instance.OnPartsChanged += OnPartsChanged;
    }

    public void OnButtonClick()
    {
        BuildingManager.Instance.ChooseBlueprint(buildingBlueprint);
    }

    public void OnPartsChanged(object sender, PartsChangedArgs args)
    {
        button.interactable = PartManager.Instance.HasRequiredParts(buildingBlueprint.cost);
    }
}
