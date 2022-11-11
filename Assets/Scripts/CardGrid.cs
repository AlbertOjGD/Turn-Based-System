using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CardGrid : MonoBehaviour
{
    private Grid grid;

    void Start()
    {
        grid = new Grid(4, 2, new Vector2(8f, 8f), this.transform.position);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), grid.GetValue(UtilsClass.GetMouseWorldPosition()) + 1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
