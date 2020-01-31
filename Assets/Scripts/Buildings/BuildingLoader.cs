using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLoader : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    private BasicBuilding buildingBlueprint;

    public void Init(BasicBuilding buildingBlueprint)
    {
        meshFilter.mesh = buildingBlueprint.mesh;
        meshRenderer.material = buildingBlueprint.material;
        this.buildingBlueprint = buildingBlueprint;
    }
}
