using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid();
        grid.PopulateGrid();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hitInfo, LayerMask.GetMask("BackgroundPlane"));
            //Debug.Log(hitInfo.point);
            Debug.Log(grid.GetCellGridCoords(hitInfo.point));
        }
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
