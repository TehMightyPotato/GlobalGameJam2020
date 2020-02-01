using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MoveSettings spaceMoveSettings;
    public MoveSettings stationMoveSettings;

    [SerializeField] private MoveSettings usedSettings;
    public Rigidbody rigidBody;

    private Vector2 input;

    private void Start()
    {
        usedSettings = stationMoveSettings;
    }

    private void CheckForGround()
    {
        var ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction);
        var rayHit = Physics.Raycast(ray, 10f, LayerMask.GetMask("Default"));
        if (rayHit)
        {
            if(usedSettings != stationMoveSettings)
            {
                usedSettings = stationMoveSettings;
            }
        }
        else if(usedSettings != spaceMoveSettings)
        {
            usedSettings = spaceMoveSettings;
        }  
    }

    private Vector2 RotateVector(Vector2 vec)
    {
        var x2 = vec.x + vec.y;
        var y2 = -vec.x + vec.y;
        return new Vector2(x2, y2);
    }

    private void FixedUpdate()
    {
        CheckForGround();
        usedSettings.Move(rigidBody, RotateVector(InputManager.Instance.MovementInput));
    }
}
