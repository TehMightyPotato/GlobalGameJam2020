﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public GameObject content;
    private Vector2Int _gridSpaceCoords;
    private Vector3 _worldSpaceCoords;

    public Vector3 WorldSpaceCoords
    {
        get
        {
            return _worldSpaceCoords;
        }
    }
    public Vector2Int GridSpaceCoords
    {
        get
        {
            return _gridSpaceCoords;
        }
    }

    public Cell(Vector2Int gridSpaceCoords, Vector3 worldSpaceCoords)
    {
        this._worldSpaceCoords = worldSpaceCoords;
        this._gridSpaceCoords = gridSpaceCoords;
    }

    public void SetContent(GameObject content)
    {
        this.content = content;
        content.transform.position = WorldSpaceCoords;
    }
}
