using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask; // filter obj interacted through the mouse
    public GameObject buildingPrefab; // instantiated prefab of building
    public int cellSize = 3; // size of each cell in game world

    void Update()
    {
        GetInput(); 
    }

    // check for mouse input
    private void GetInput()
    {   
        // check is left mouse clicked & ensure pointer not over UI elements
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // cast ray from camera to mouse position
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // retrieve hit pos if ray hits an obj
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
            {
                // calculate nearest grid position
                Vector3 position = hit.point-transform.position;
                Debug.Log(CalculateGridPosition(position));
                // instantiate the building prefab
                CreatebUilding(CalculateGridPosition(position));
            }
        }   
    }

    // calculate grid pos based on cellSize
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x/cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
        return new Vector3(x * cellSize, 0, z * cellSize);
    }
    
    // instantiate buildingprefab at specified gridPosition
    private void Createbuilding(Vector3 gridPosition)
    {
        Instantiate(bUildingPrefab, gridPosition, Quaternion.identity);
    }
}
