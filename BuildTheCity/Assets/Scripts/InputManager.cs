using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask; // filter obj interacted through the mouse

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
            }
        }   
    }

    // // instantiate buildingprefab at specified gridPosition
    // private void Createbuilding(Vector3 gridPosition)
    // {
    //     Instantiate(bUildingPrefab, gridPosition, Quaternion.identity);
    // }
}
