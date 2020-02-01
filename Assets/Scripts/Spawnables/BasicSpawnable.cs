using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawnables/BasicSpawnable")]
public class BasicSpawnable : ScriptableObject
{
    public Sprite sprite;
    public Material material;
    public SpawnRegion spawnRegion;
    public Reward[] rewards;



    public void OnCollect()
    {
        var totalCount = 0;
        foreach (var reward in rewards)
        {
            totalCount += reward.chance;
        }
        var rand = Random.Range(0, totalCount);
        foreach (var reward in rewards)
        {
            rand -= reward.chance;
            if (rand <= 0)
            {
                foreach (var actualReward in reward.rewards)
                {
                    PartManager.Instance.ChangePartCount(actualReward.part.partName, actualReward.ammount);
                }
            }
        }
    }
}

public enum SpawnRegion
{
    Near,
    Middle,
    Far
}

[System.Serializable]
public struct Reward
{
    [Range(1, 100)]
    public int chance;
    public Cost[] rewards;
}
