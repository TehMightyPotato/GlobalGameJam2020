using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Buildings/EnergyStorageBulding")]
public class EnergyStorageBuilding : BasicBuilding
{
    public int energyCapacity;

    public override void Init(GameObject obj)
    {
        PartManager.Instance.RegisterEnergyStorage(energyCapacity);
    }

    public override void OnBeforeDestroy()
    {
        if(PartManager.Instance != null)
        {
            PartManager.Instance.DeregisterEnergyStorage(energyCapacity);
        }
    }
}
