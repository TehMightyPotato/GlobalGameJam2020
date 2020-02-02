using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private InputManager inputManager;
    public Rigidbody rigidBody;

    public LineRenderer lRenderer;
    private bool ropeActive;
    private Vector3 connectionPoint;
    public float ropeLength;
    private float temporaryRopeLenght;
    public float ropePullSpeed;
    public float ropeForce;


    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        lRenderer.SetPosition(1, transform.position + Vector3.down);
    }

    public void SetActive(bool val)
    {
        if (val)
        {
            connectionPoint = transform.position + Vector3.down;
            lRenderer.SetPosition(0, connectionPoint);
            lRenderer.SetPosition(1, transform.position + Vector3.down);
            temporaryRopeLenght = ropeLength;
        }
        lRenderer.enabled = val;
        ropeActive = val;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(connectionPoint, transform.position) > temporaryRopeLenght && ropeActive)
        {
            var dir = -(transform.position - connectionPoint).normalized;
            var pull = Vector3.Distance(connectionPoint, transform.position) - temporaryRopeLenght;
            rigidBody.AddForce(dir * pull * ropeForce, ForceMode.Impulse);
        }
        if(ropeActive && inputManager.RopeInput)
        {
            var dir = -(transform.position - connectionPoint).normalized;
            rigidBody.AddForce(dir  * ropeForce, ForceMode.Impulse);
        }
    }
}
