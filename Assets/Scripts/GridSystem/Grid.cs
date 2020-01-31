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

    public void PopulateGrid()
    {
        for(int x = 0; x < gridXSize; x++)
        {
            for(int y = 0; y < gridYSize; y++)
            {
                var vec = new Vector2Int(x, y);
                gridDict[vec] = new Cell(vec);
            }
        }
    }
}
