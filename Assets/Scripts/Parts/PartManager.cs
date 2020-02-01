using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : Singleton<PartManager>
{
    public EventHandler<PartsChangedArgs> OnPartsChanged;
    public void PartsChanged(object sender)
    {
        OnPartsChanged?.Invoke(sender, new PartsChangedArgs(inventory));
    }

    public Dictionary<string, int> inventory = new Dictionary<string, int>();


    private void Start()
    {
        ChangePartCount("Metal", 4);
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
}

public class PartsChangedArgs : EventArgs
{
    public Dictionary<string, int> partDict;

    public PartsChangedArgs(Dictionary<string, int> partDict)
    {
        this.partDict = partDict;
    }
}
