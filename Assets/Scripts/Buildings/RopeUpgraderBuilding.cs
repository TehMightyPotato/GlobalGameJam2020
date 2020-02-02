using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Buildings/RopeUpgradeBuilding")]
public class RopeUpgraderBuilding : BasicBuilding
{
    public float ropeLength;
    public Material mat;

    public override void Init(GameObject obj)
    {
        var rope = GameObject.FindGameObjectWithTag("Player").GetComponent<Rope>();
        rope.gameObject.GetComponent<LineRenderer>().material = mat;
        rope.ropeLength = ropeLength;
    }
}
