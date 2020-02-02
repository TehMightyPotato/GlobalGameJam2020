using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : Singleton<TooltipManager>
{
    public GameObject partElementPrefab;
    private List<GameObject> objList = new List<GameObject>();

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void PurgeList()
    {
        foreach(var element in objList)
        {
            Destroy(element);
        }
        objList = new List<GameObject>();
        gameObject.SetActive(false);
    }

    public void PopulateList(BasicBuilding building)
    {
        foreach (var cost in building.cost)
        {
            var obj = Instantiate(partElementPrefab, transform);
            var text = obj.GetComponent<UIPartsElementLoader>().Init(cost.part.partName);
            objList.Add(obj);
            text.text = cost.ammount.ToString();
        }
        gameObject.SetActive(true);
    }
}
