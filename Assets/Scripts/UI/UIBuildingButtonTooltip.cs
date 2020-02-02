using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBuildingButtonTooltip : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public GameObject partElementPrefab;
    public TooltipManager tooltipManager;
    public BasicBuilding blueprint;
    

    public void Init(BasicBuilding building)
    {
        tooltipManager = TooltipManager.Instance;
        this.blueprint = building;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipManager.PopulateList(blueprint);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipManager.PurgeList();
    }

}
