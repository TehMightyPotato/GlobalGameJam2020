using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Buildings/ProducerBuilding")]
public class ProducerBuilding : BasicBuilding
{
    public BasicPart product;
    public int productionRate;
    public int productionTicks;

    public override void  Init(GameObject obj)
    {
        var producer = obj.AddComponent<Producer>();
        producer.Init(product.partName, productionRate, productionTicks);
    }
}
