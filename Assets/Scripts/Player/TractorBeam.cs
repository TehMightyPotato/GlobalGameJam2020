using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public InputManager inputManager;
    public float sphereCastRadius;
    public float sphereCastDistance;
    public float pullForceMultiplier;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void FixedUpdate()
    {
        if (inputManager.TractorBeamActive)
        {
            var direction = inputManager.MousePosition - transform.position;
            direction.y = 0;
            var ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction);
            var hitInfo = Physics.SphereCastAll(ray, sphereCastRadius, sphereCastDistance);
            foreach(var hit in hitInfo)
            {
                if (hit.transform.CompareTag("Spawnable"))
                {
                    hit.transform.GetComponent<Spawnable>().MoveTowards(transform.position, pullForceMultiplier);
                }
            }
        }
    }
}
