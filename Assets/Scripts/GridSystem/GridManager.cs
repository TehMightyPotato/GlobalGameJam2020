using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Grid grid;
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
        if (Input.GetButtonDown("Fire1"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hitInfo, LayerMask.GetMask("BackgroundPlane"));
            var coords = grid.GetCellGridCoords(hitInfo.point);
            if (!CellCheckPlaceablility(coords)) return;
            PlaceBuilding(blueprint, coords);
        }
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

    public bool CellCheckPlaceablility(Vector2Int position)
    {
        return grid.CellHasNeighbour(position) && !grid.CellHasContent(position);
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
