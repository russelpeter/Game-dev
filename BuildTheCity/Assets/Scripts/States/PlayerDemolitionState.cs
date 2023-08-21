using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemolitionState : PlayerState
{
    BuildingManager buildingManager;
    public PlayerDemolitionState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager)
    {
        this.buildingManager = buildingManager;
    }
     
    public override void OnCancle()
    {
        this.buildingManager.CancleModification();
        this.gameManager.TransitionToState(this.gameManager.selectionState, null);
    }

    public override void OnConfirmAction()
    {
        this.buildingManager.ConfirmModification();
        AudioManager.Instance.PlayDemolitionSound();
        base.OnConfirmAction();
    }

    public override void OnInputPointerChange(Vector3 position)
    {
        return;
    }

    public override void OnBuildArea(string structureName)
    {
        this.buildingManager.CancleModification();
        base.OnBuildArea(structureName);
    }

    public override void OnBuildRoad(string structureName)
    {
        this.buildingManager.CancleModification();
        base.OnBuildRoad(structureName);
    }

    public override void OnBuildSingleStructure(string structureName)
    {
        this.buildingManager.CancleModification();
        base.OnBuildSingleStructure(structureName);
    }


    public override void OnInputPointerDown(Vector3 position)
    {
        this.buildingManager.PrepareStructureForDemolitionAt(position);
    }

    public override void OnInputPointerUp()
    {
        return;
    }

    public override void EnterState(string variable)
    {
        this.buildingManager.PrepareBuildingManager(this.GetType());
    }
}
