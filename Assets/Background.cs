using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform player;
    public float mult;
    public void Update()
    {
        var vect = player.position * mult;
        vect.y = -5;
        transform.position = vect;
    }
}
