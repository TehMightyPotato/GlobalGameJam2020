using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingMenuButtonLoader : MonoBehaviour
{
    public BasicBuilding buildingBlueprint;
    public Image buttonImage;

    public void Init(BasicBuilding building)
    {
        buildingBlueprint = building;
        buttonImage.sprite = building.buildingIcon;
    }

    public void OnButtonClick()
    {
        GridManager.Instance.SelectBuilding(buildingBlueprint);
    }
}
