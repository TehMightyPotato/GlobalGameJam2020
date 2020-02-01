using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : Singleton<BuildingManager>
{
    public GridManager gridManager;
    public BasicBuilding selectedBlueprint;

    public void ChooseBlueprint(BasicBuilding blueprint)
    {
        selectedBlueprint = blueprint;
    }

    public void Build(BasicBuilding blueprint, Vector3 position, bool cheat = false)
    {
        if (cheat || (PartManager.Instance.HasRequiredParts(blueprint.cost) && gridManager.CellCheckPlaceablility(position)))
        {
            if (!cheat)
            {
                PartManager.Instance.SubractCost(blueprint.cost);
            }
            gridManager.PlaceBuilding(blueprint, position);
        }
    }

    public void Build(Vector3 position)
    {
        Build(selectedBlueprint, position);
    }
}
