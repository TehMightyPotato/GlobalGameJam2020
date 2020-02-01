using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPartsManager : MonoBehaviour
{
    Dictionary<string, Text> uiObjects = new Dictionary<string, Text>();
    public GameObject partElementPrefab;

    private void Start()
    {
        PartManager.Instance.OnPartsChanged += OnPartsChanged;
    }

    public void OnPartsChanged(object sender, PartsChangedArgs args)
    {
        foreach (var element in args.partDict.Keys)
        {
            if (uiObjects.ContainsKey(element))
            {
                uiObjects[element].text = args.partDict[element].ToString();
            }
            else
            {
                var obj = Instantiate(partElementPrefab, transform);
                uiObjects.Add(element, obj.GetComponent<UIPartsElementLoader>().Init(element));
                uiObjects[element].text = args.partDict[element].ToString();
            }
        }
    }
}
