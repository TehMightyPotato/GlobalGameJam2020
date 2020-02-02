using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : Singleton<BuildingManager>
{
    public GridManager gridManager;
    public BasicBuilding selectedBlueprint;
    [Range(0,1)]
    public float soundVolume;

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
            SoundManager.Instance.PlayAudioClip("Bauelement", soundVolume);
            gridManager.PlaceBuilding(blueprint, position);
        }
    }

    public void Build(Vector3 position)
    {
        Build(selectedBlueprint, position);
    }

    public void DestroyBuilding(Vector3 mousePosition)
    {
        gridManager.DestroyBuilding(mousePosition);
    }
}
