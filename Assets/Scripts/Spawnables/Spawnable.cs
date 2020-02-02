using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    [Range(0,100)]
    public int shoutOutChance;
    [Range(0,1)]
    public float soundVolume;
    public BasicSpawnable blueprint;
    new public SpriteRenderer renderer;
    public Rigidbody rigidBody;
    public float rotateSpeed;
    public float maxDistanceFromZero;
    private Coroutine collisionRoutine;
    private Sphere sphere;
    private Quaternion rotation;
    private bool orbitEnabled;

    public void Init(BasicSpawnable blueprint, Sphere sphere)
    {
        this.sphere = sphere;
        this.blueprint = blueprint;
        renderer.sprite = this.blueprint.sprite;
        renderer.material = this.blueprint.material;
        rotation = Quaternion.Euler(45, 45, 0);
        orbitEnabled = true;
        rotateSpeed = Random.Range(-rotateSpeed, rotateSpeed);
    }

    private void Update()
    {
        if(maxDistanceFromZero < Vector3.Distance(transform.position, Vector3.zero))
        {
            sphere.RemoveObjectFromList(gameObject);
            Destroy(gameObject);
        }
        if (orbitEnabled)
        {
            transform.rotation = rotation;
            transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * rotateSpeed);
        }
    }

    public void MoveTowards(Vector3 point, float pullForceMultiplier)
    {
        if (orbitEnabled)
        {
            orbitEnabled = false;
        }
        rigidBody.AddForce((point - transform.position).normalized * pullForceMultiplier, ForceMode.Impulse);
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
        var rng = Random.Range(1, 101);
        if(rng <= shoutOutChance)
        {
            SoundManager.Instance.PlayRandomShoutout();
        }
        SoundManager.Instance.PlayAudioClip("Abbauen",soundVolume);
        rigidBody.isKinematic = true;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield break;
    }
}
