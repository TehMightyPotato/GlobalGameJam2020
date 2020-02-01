using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnablePrefab;
    public Transform player;
    public float spawnHeight;
    public float minDistanceToPlayer;

    public Sphere innerSphere;
    public Sphere middleSphere;
    public Sphere outerSphere;


    private void Start()
    {
        var innerLootTable = new List<BasicSpawnable>();
        var middleLootTable = new List<BasicSpawnable>();
        var outerLootTable = new List<BasicSpawnable>();

        var resLoad = Resources.LoadAll<BasicSpawnable>("Spawnables/");
        foreach(var element in resLoad)
        {
            switch (element.spawnRegion)
            {
                case SpawnRegion.Near:
                    innerLootTable.Add(element);
                    goto case SpawnRegion.Middle;
                case SpawnRegion.Middle:
                    middleLootTable.Add(element);
                    goto case SpawnRegion.Far;
                case SpawnRegion.Far:
                    outerLootTable.Add(element);
                    break;
            }
        }

        innerSphere.Init(spawnablePrefab,transform,player,spawnHeight,innerLootTable, minDistanceToPlayer);
        middleSphere.Init(spawnablePrefab,transform, player, spawnHeight, middleLootTable, minDistanceToPlayer);
        outerSphere.Init(spawnablePrefab, transform, player, spawnHeight, outerLootTable, minDistanceToPlayer);
    }

    private void FixedUpdate()
    {
        innerSphere.SpawnObject();
        middleSphere.SpawnObject();
        outerSphere.SpawnObject();
    }
}

[System.Serializable]
public class Sphere
{
    public float startRadius;
    public float endRadius;
    public int maxObjectCount;
    private List<BasicSpawnable> spawnTable = new List<BasicSpawnable>();
    private List<GameObject> objectList = new List<GameObject>();
    private float minDistanceToPlayer;
    private float spawnHeight;
    private GameObject spawnablePrefab;
    private Transform parent;
    private Transform playerTrans;

    public void Init(GameObject spawnablePrefab, Transform parent, Transform playerTrans, float spawnHeight, List<BasicSpawnable> spawnTable, float minDistanceToPlayer)
    {
        this.spawnablePrefab = spawnablePrefab;
        this.parent = parent;
        this.playerTrans = playerTrans;
        this.spawnHeight = spawnHeight;
        this.spawnTable = spawnTable;
        this.minDistanceToPlayer = minDistanceToPlayer;
    }

    public void SpawnObject()
    {
        if(objectList.Count <= maxObjectCount)
        {
            var obj = GameObject.Instantiate(spawnablePrefab, GetRandomPosition(), Quaternion.identity, parent);
            obj.GetComponent<Spawnable>().Init(GetRandomBlueprint(), this);
            objectList.Add(obj);
        }
    }

    public void RemoveObjectFromList(GameObject obj)
    {
        objectList.Remove(obj);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 point;
        do
        {
            var distance = Random.Range(startRadius, endRadius);
            var pnt = Random.insideUnitCircle.normalized * distance;
            point = new Vector3(pnt.x, spawnHeight, pnt.y);

        }
        while (Vector3.Distance(point, playerTrans.position) < minDistanceToPlayer);
        return point;
    }

    private BasicSpawnable GetRandomBlueprint()
    {
        return spawnTable[Random.Range(0, spawnTable.Count)];
    }
}
