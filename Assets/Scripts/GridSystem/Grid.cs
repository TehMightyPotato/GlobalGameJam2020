using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
    public Dictionary<Vector2Int, Cell> gridDict = new Dictionary<Vector2Int, Cell>();
    public int gridXSize = 100;
    public int gridYSize = 100;


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

    public void PopulateGrid()
    {
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                GetCell(new Vector2Int(x, y));
            }
        }
    }
}
