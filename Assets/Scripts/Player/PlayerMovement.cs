using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MoveSettings spaceMoveSettings;
    public MoveSettings stationMoveSettings;

    public Animator anim;

    [SerializeField] private MoveSettings usedSettings;
    public Rigidbody rigidBody;
    public Rope rope;

    private void Start()
    {
        usedSettings = stationMoveSettings;
    }

    public void Update(){
        anim.SetBool("Walk", InputManager.Instance.MovementInput.magnitude > 0.5f && usedSettings == stationMoveSettings);
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
                GameManager.Instance.PlayerLocationChanged(this, true);
                rope.SetActive(false);
            }
        }
        else if(usedSettings != spaceMoveSettings)
        {
            usedSettings = spaceMoveSettings;
            GameManager.Instance.PlayerLocationChanged(this, false);
            rope.SetActive(true);
        }  
    }

    private Vector2 RotateVector(Vector2 vec)
    {
        var x2 = vec.x + vec.y;
        var y2 = -vec.x + vec.y;
        return new Vector2(x2, y2);
    }

    private bool CheckForEnergy()
    {
        if(PartManager.Instance.GetPartCount("Energy") > 0)
        {
            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        CheckForGround();
        if (usedSettings == spaceMoveSettings && !CheckForEnergy())
        {
            return;
        }
        usedSettings.Move(rigidBody, RotateVector(InputManager.Instance.MovementInput));
    }
}