using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConst : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    public bool local;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (local)
        {
            transform.position += transform.TransformDirection(direction) * Time.deltaTime * speed;
        } 
        else
        {
            transform.position += direction * Time.deltaTime * speed;

        }
    }
}
