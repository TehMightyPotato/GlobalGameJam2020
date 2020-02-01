using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="Parts/BasicPart")]
public class BasicPart : ScriptableObject
{
    public string partName;
    public Sprite icon;
}
