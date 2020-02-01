using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLoader : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    new public MeshCollider collider;
    private BasicBuilding buildingBlueprint;

    public void Init(BasicBuilding buildingBlueprint)
    {
        meshFilter.mesh = buildingBlueprint.mesh;
        meshRenderer.material = buildingBlueprint.material;
        collider.sharedMesh = buildingBlueprint.mesh;
        this.buildingBlueprint = buildingBlueprint;
    }
}
