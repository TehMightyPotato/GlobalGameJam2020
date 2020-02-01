using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MoveSettings/SpaceMoveSettings")]
public class SpaceMoveSettings : MoveSettings
{
    [Range(0,1)]
    public float forceMultiplier;

    public override void Move(Rigidbody rb, Vector2 input)
    {
        rb.AddForce(new Vector3(input.x,0,input.y).normalized * forceMultiplier, ForceMode.Impulse);
    }
}
