using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Buildings/BasicBuilding")]
public class BasicBuilding : ScriptableObject
{
    public string buildingName;
    public Sprite buildingIcon;
    public Mesh mesh;
    public Material material;
    public Cost[] cost;

}

[System.Serializable]
public struct Cost
{
    public BasicPart part;
    public int ammount;
}

