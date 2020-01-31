using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public GameObject content;
    private Vector2Int _worldSpaceCoords;
    public Vector2Int WorldSpaceCoords
    {
        get
        {
            return _worldSpaceCoords;
        }
    }

    public Cell(Vector2Int worldSpaceCoords)
    {
        this._worldSpaceCoords = WorldSpaceCoords;
    }

    public Cell(int x, int z)
    {
        this._worldSpaceCoords = new Vector2Int(x, z);
    }
}
