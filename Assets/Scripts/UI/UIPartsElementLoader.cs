using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPartsElementLoader : MonoBehaviour
{
    public Image icon;
    public Text text;

    public Text Init(string partName)
    {
        icon.sprite = PartManager.Instance.partLookupDict[partName].icon;
        return text;
    }
}
