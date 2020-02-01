using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIBuildingMenuContentLoader : MonoBehaviour
{
    public GameObject elementPrefab;
    public Dictionary<BuildingType, List<BasicBuilding>> blueprintDict = new Dictionary<BuildingType, List<BasicBuilding>>();

    public void Init()
    {
        var blueprints = Resources.LoadAll<BasicBuilding>("Buildings/");

        foreach (var category in (BuildingType[])Enum.GetValues(typeof(BuildingType)))
        {
            blueprintDict.Add(category, new List<BasicBuilding>());
        }
        foreach(var element in blueprints)
        {
            blueprintDict[element.buildingType].Add(element);
        }
        foreach(var key in blueprintDict.Keys)
        {
            var list = blueprintDict[key];
            var obj = Instantiate(elementPrefab, transform);
            obj.GetComponent<UIElementLoader>().Init(list,key.ToString("g"));
        }
    }
}
