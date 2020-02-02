﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : Singleton<PartManager>
{
    public int maxEnergy;

    public EventHandler<PartsChangedArgs> OnPartsChanged;
    public void PartsChanged(object sender)
    {
        OnPartsChanged?.Invoke(sender, new PartsChangedArgs(inventory));
    }
    public Dictionary<string, BasicPart> partLookupDict;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    private void Start()
    {
        partLookupDict = new Dictionary<string, BasicPart>();
        foreach (var part in Resources.LoadAll<BasicPart>("Parts/"))
        {
            partLookupDict.Add(part.partName, part);
        }
        ChangePartCount("Metal", 4);
        ChangePartCount("Energy", 10);
    }

    public int GetPartCount(string partName)
    {
        if (inventory.ContainsKey(partName))
        {
            return inventory[partName];
        }
        return 0;
    }

    public void ChangePartCount(string partName, int ammount)
    {
        if (!inventory.ContainsKey(partName))
        {
            inventory.Add(partName, 0);
        }
        inventory[partName] += ammount;
        if (partName == "Energy" && GetPartCount(partName) > maxEnergy)
        {
            inventory[partName] = maxEnergy;
        }
        PartsChanged(this);
    }

    public void SubractCost(Cost[] cost)
    {
        foreach (var element in cost)
        {
            ChangePartCount(element.part.partName, -element.ammount);
        }
    }

    public bool HasRequiredParts(Cost[] cost)
    {
        foreach (var resource in cost)
        {
            if (GetPartCount(resource.part.partName) < resource.ammount)
            {
                return false;
            }
        }
        return true;
    }

    public void RegisterEnergyStorage(int capacity)
    {
        maxEnergy += capacity;
    }

    public void DeregisterEnergyStorage(int capacity)
    {
        maxEnergy -= capacity;
    }
}

public class PartsChangedArgs : EventArgs
{
    public Dictionary<string, int> partDict;

    public PartsChangedArgs(Dictionary<string, int> partDict)
    {
        this.partDict = partDict;
    }
}
