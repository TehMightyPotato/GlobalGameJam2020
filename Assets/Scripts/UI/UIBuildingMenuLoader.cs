using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingMenuLoader : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject elementContent;
    public Text headerText;


    public void Init(List<BasicBuilding> buildingList, string headerText)
    {
        this.headerText.text = headerText;

        foreach (var element in buildingList)
        {
            var obj = Instantiate(buttonPrefab, elementContent.transform);
            obj.GetComponent<UIBuildingMenuButtonLoader>().Init(element);
        }
    }
}
