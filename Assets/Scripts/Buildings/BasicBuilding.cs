﻿using System.Collections;
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
    public BuildingType buildingType;

    public virtual void Operate()
    {

    }

    public virtual void Init(GameObject obj)
    {

    }

    public virtual void OnBeforeDestroy()
    {

    }

}

[System.Serializable]
public struct Cost
{
    public BasicPart part;
    public int ammount;
}

[System.Serializable]
public enum BuildingType
{
    Platform,
    Production, 
    Storage, 
    Upgrade,
    Required
}

