﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
    public Dictionary<Vector2Int, Cell> gridDict = new Dictionary<Vector2Int, Cell>();

    public Vector3 GetCellWorldCoords(Vector2Int gridPos)
    {
        return new Vector3(gridPos.x + 0.5f, 0, gridPos.y + 0.5f);
    }

    public Vector2Int GetCellGridCoords(Vector3 worldPos)
    {
        return new Vector2Int(Mathf.FloorToInt(worldPos.x), Mathf.FloorToInt(worldPos.z));
    }

    public Cell GetCell(Vector2Int gridPos)
    {
        if (!gridDict.ContainsKey(gridPos))
        {
            gridDict[gridPos] = new Cell(gridPos, GetCellWorldCoords(gridPos));
        }
        return gridDict[gridPos];
    }

    public void RemoveCell(Vector2Int position)
    {
        if (gridDict.ContainsKey(position))
        {
            var content = gridDict[position].content;
            if (content != null)
            {
                SoundManager.Instance.PlayAudioClip("Bauelement", 1);
            }
            GameObject.Destroy(content);
            gridDict.Remove(position);
        }
    }

    public void SetProtected(Vector2Int position)
    {
        gridDict[position].SetProtected();
    }

    public bool CellHasContent(Vector2Int gridPos)
    {
        return GetCell(gridPos).content ? true : false;
    }

    public void CellSetContent(Vector2Int gridPos, GameObject content)
    {
        GetCell(gridPos).content = content;
    }

    public bool CellHasNeighbour(Vector2Int gridPos)
    {
        if (CellHasContent(gridPos + new Vector2Int(-1, 0))) return true;
        if (CellHasContent(gridPos + new Vector2Int(1, 0))) return true;
        if (CellHasContent(gridPos + new Vector2Int(0, -1))) return true;
        if (CellHasContent(gridPos + new Vector2Int(0, 1))) return true;
        return false;
    }
}
