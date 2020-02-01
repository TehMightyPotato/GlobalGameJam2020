using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public BasicSpawnable blueprint;
    new public SpriteRenderer renderer;
    private Coroutine collisionRoutine;
    private Sphere sphere;
    private Quaternion rotation;
    public float rotateSpeed;

    public void Init(BasicSpawnable blueprint)
    {
        this.blueprint = blueprint;
        renderer.sprite = this.blueprint.sprite;
        renderer.material = this.blueprint.material;
        rotation = Quaternion.Euler(45, 45, 0);
        rotateSpeed = Random.Range(-rotateSpeed, rotateSpeed);
    }

    private void Update()
    {
        transform.rotation = rotation;
        transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && collisionRoutine == null)
        {
            collisionRoutine = StartCoroutine(CollisionRoutine());
        }
    }

    public IEnumerator CollisionRoutine()
    {
        blueprint.OnCollect();
        sphere.RemoveObjectFromList(gameObject);
        Destroy(gameObject);
        yield break;
    }
}
