using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveSettings : ScriptableObject
{
    public abstract void Move(Rigidbody rb, Vector2 input);
}
