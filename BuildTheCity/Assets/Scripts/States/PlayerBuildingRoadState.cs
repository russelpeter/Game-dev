using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingRoadState : PlayerState
{
    BuildingManager buildingManager;
    string structureName;

    public PlayerBuildingRoadState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager)
    {
        this.buildingManager = buildingManager;
    }

    public override void OnCancle()
    {
        this.buildingManager.CancleModification();
        this.gameManager.TransitionToState(this.gameManager.selectionState, null);
    }

    public override void OnBuildArea(string structureName)
    {
        this.buildingManager.CancleModification();
        base.OnBuildArea(structureName);
    }

    public override void OnBuildSingleStructure(string structureName)
    {
        this.buildingManager.CancleModification();
        base.OnBuildSingleStructure(structureName);
    }

    public override void OnConfirmAction()
    {
        
        this.buildingManager.ConfirmModification();
        AudioManager.Instance.PlayPlaceBuildingSound();
        base.OnConfirmAction();
    }

    public override void EnterState(string structureName)
    {
        this.buildingManager.PrepareBuildingManager(this.GetType());
        this.structureName = structureName;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        this.buildingManager.PrepareStructureForModification(position, this.structureName, StructureType.Road);
    }
}
