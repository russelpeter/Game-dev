using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    // store what structure was placed on a cell
    GameObject structureModel = null;
    bool isTaken = false; // if there's a structure on e cell

    public bool IsTaken { get => isTaken;}

    public void SetConstruction(GameObject structureModel)
    {
        if (structureModel == null)
            return;
        this.structureModel = structureModel;
        this.isTaken = true;
    }

     public GameObject GetStructure()
    {
        return structureModel;
    }

    public void RemoveStructure()
    {
        structureModel = null;
        isTaken = false;
    }
}
