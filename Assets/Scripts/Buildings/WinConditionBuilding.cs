using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Buildings/WinConditionBuilding")]
public class WinConditionBuilding : BasicBuilding
{
    public WinCondition condition;
    public override void Init(GameObject obj)
    {
        GameManager.Instance.SetWinCondition(1, condition);
    }

    public override void OnBeforeDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.SetWinCondition(-1, condition);
        }
    }
}

public enum WinCondition
{
    Navigation,
    Shield,
    Booster
}
