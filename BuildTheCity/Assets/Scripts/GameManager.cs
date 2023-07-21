using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    // public InputManager inputManager;
    public IInputManager inputManager;
    public UIController uiController;
    public int width, length;
    public GridStructure grid;
    private int cellSize = 3;
    private bool buildingModeActive = false;

    void Start()
    {
        // find every instance of IInputManager
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        grid = new GridStructure(cellSize, width, length);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancelActionEvent(CancelAction);
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (buildingModeActive && grid.IsCellTaken(gridPosition) == false)
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }

    private void StartPlacementMode()
    {
        buildingModeActive = true;
    }

    private void CancelAction()
    {
        buildingModeActive = false;
    }
}
