using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{
    private string partName;
    private int productionRate;
    private int productionTicks;
    private int tickCounter;
    private PartManager partManager;
    new private bool enabled;

    public void Init(string partName, int productionRate, int productionTicks)
    {
        this.partName = partName;
        this.productionRate = productionRate;
        this.productionTicks = tickCounter = productionTicks;
        partManager = PartManager.Instance;
        enabled = true;
        GameManager.Instance.OnPlayerLocationChanged += OnPlayerLocationChanged;
    }

    public virtual void Operate()
    {
        if (!enabled) return;
        tickCounter -= 1;
        if(tickCounter == 0)
        {
            partManager.ChangePartCount(partName,productionRate);
            tickCounter = productionTicks;
        }
    }

    public void OnPlayerLocationChanged(object sender, LocationChangedArgs args)
    {
        enabled = args.onStation;
    }

    private void FixedUpdate()
    {
        Operate();
    }
}
