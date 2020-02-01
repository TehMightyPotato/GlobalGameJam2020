using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MoveSettings/StationMoveSettings")]
public class StationMoveSettings : MoveSettings
{
    [Range(0, 10)]
    public float forceMultiplier;
    [Range(0, 10)]
    public float dragMultiplier;
    public float maxVelocity;

    public override void Move(Rigidbody rb, Vector2 input)
    {
        rb.AddForce(new Vector3(input.x, 0, input.y).normalized * forceMultiplier, ForceMode.Impulse);
        if (rb.velocity.magnitude >= maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        if (input.magnitude <= 0.1f)
        {
            rb.AddForce(-rb.velocity * dragMultiplier, ForceMode.Impulse);
        }
    }
}
