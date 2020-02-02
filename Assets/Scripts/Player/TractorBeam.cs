using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public InputManager inputManager;
    public float sphereCastRadius;
    public float sphereCastDistance;
    public float pullForceMultiplier;
    public GameObject tractorBeam;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void FixedUpdate()
    {
        if (inputManager.TractorBeamActive)
        {
            if (!tractorBeam.activeSelf)
            {
                tractorBeam.SetActive(true);
            }
            var direction = inputManager.MousePosition - transform.position;
            direction.y = 0;
            var particleAngle = Vector2.SignedAngle(Vector2.up, new Vector2(direction.x, direction.z));
            tractorBeam.transform.rotation = Quaternion.Euler(0, -particleAngle - 90, 0);
            var ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction);
            var hitInfo = Physics.SphereCastAll(ray, sphereCastRadius, sphereCastDistance);
            foreach (var hit in hitInfo)
            {
                if (hit.transform.CompareTag("Spawnable"))
                {
                    hit.transform.GetComponent<Spawnable>().MoveTowards(transform.position, pullForceMultiplier);
                }
            }
        }
        else
        {
            if (tractorBeam.activeSelf)
            {
                tractorBeam.SetActive(false);
            }
        }
    }
}
