using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    public Camera mainCam;
    private Grid grid;
    public GameObject prefab;
    public BasicBuilding blueprint;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid();
        PopulateGrid();
    }

    private void Update()
    {

    }

    public void PopulateGrid()
    {
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                PlaceBuilding(blueprint, new Vector2Int(x, y));
            }
        }
    }

    public void PlaceBuilding(BasicBuilding blueprint,Vector2Int position)
    {
        var cell = grid.GetCell(position);
        var obj = GameObject.Instantiate(prefab);
        obj.GetComponent<BuildingLoader>().Init(blueprint);
        cell.SetContent(obj);
    }

    public void PlaceBuilding(BasicBuilding blueprint, Vector3 position)
    {
        var coords = grid.GetCellGridCoords(position);
        PlaceBuilding(blueprint, coords);
    }

    public bool CellCheckPlaceablility(Vector2Int position)
    {
        return grid.CellHasNeighbour(position) && !grid.CellHasContent(position);
    }

    public bool CellCheckPlaceablility(Vector3 position)
    {
        return CellCheckPlaceablility(grid.GetCellGridCoords(position));
    }

    private void OnDrawGizmos()
    {
        if (!EditorApplication.isPlaying)
            return;
        foreach (var position in grid.gridDict.Keys)
        {
            Gizmos.DrawWireCube(grid.GetCellWorldCoords(position), new Vector3(1, 0.1f, 1));
        }
    }
}
