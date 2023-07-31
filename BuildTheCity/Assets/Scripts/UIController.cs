using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // delegates to inform action was performed
    private Action OnBuildAreaHandler;
    private Action OnCancelActionHandler;
    private Action OnDemolishActionHandler;

    public StructureRepository structureRepository;
    public Button buildResidentialAreaBtn;
    public Button cancelActionBtn;
    public GameObject cancelActionPanel;

    public GameObject buildingMenuPanel;
    public Button openBuildMenuBtn;
    public Button demolishBtn;

    public GameObject zonesPanel;
    public GameObject facilitiesPanel;
    public GameObject roadsPanel;
    public Button closeBuildMenuBtn;

    public GameObject buildButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // hide cancelActPanel at game start
        cancelActionPanel.SetActive(false);
        buildingMenuPanel.SetActive(false);
        // buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelActionCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        demolishBtn.onClick.AddListener(OnDemolishHandler);
        closeBuildMenuBtn.onClick.AddListener(OnCloseMenuHandler);
    }

    private void OnCloseMenuHandler()
    {
        buildingMenuPanel.SetActive(false);
    }

    private void OnDemolishHandler()
    {
        OnDemolishActionHandler?.Invoke();
        cancelActionPanel.SetActive(true);
        // buildingMenuPanel.SetActive(false);
        OnCloseMenuHandler();
    }

    private void OnOpenBuildMenu()
    {
        buildingMenuPanel.SetActive(true);
        PrepareBuildMenu();
    }

    private void PrepareBuildMenu()
    {
        CreateButtonsInPanel(zonesPanel.transform, structureRepository.GetZoneNames());
        CreateButtonsInPanel(facilitiesPanel.transform, structureRepository.GetSingleStructureNames());
        CreateButtonsInPanel(roadsPanel.transform, new List<string>() { structureRepository.GetRoadStructureName() });
    }

    // private void CreateButtonsInPanel(Transform panelTransform)
    private void CreateButtonsInPanel(Transform panelTransform, List<string> dataToShow)
    {
        // // foreach (Transform child in panelTransform)
        if (dataToShow.Count > panelTransform.childCount)
        {
        //     // var button = child.GetComponent<Button>();
        //     // if(button!= null)
            int quantityDifference = dataToShow.Count - panelTransform.childCount;
            for (int i = 0; i < quantityDifference; i++)
            {
                Instantiate(buildButtonPrefab, panelTransform);
                // button.onClick.RemoveAllListeners();
                // button.onClick.AddListener(OnBuildAreaCallback);
            }
        }

        for (int i = 0; i < panelTransform.childCount; i++)
        {
            var button = panelTransform.GetChild(i).GetComponent<Button>();
            if (button != null)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = dataToShow[i];
                button.onClick.AddListener(OnBuildAreaCallback);
            }
        }
    }

   // call events when buttons are actually pressed
    private void OnBuildAreaCallback()
    {
        cancelActionPanel.SetActive(true);// show panel
        // buildingMenuPanel.SetActive(false);
        OnCloseMenuHandler();
        OnBuildAreaHandler?.Invoke(); // ? checks if null ot not
    }

    private void OnCancelActionCallback()
    {
        cancelActionPanel.SetActive(false); // hide panel when peressed
        OnCancelActionHandler?.Invoke();
    }

   // add listeners & remove them
    public void AddListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler += listener;
    }

    public void RemoveListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler -= listener;
    }
    public void AddListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler += listener;
    }

    public void RemoveListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler -= listener;
    }

    public void AddListenerOnDemolishActionEvent(Action listener)
    {
        OnDemolishActionHandler += listener;
    }

    public void RemoveListenerOnDemolishActionEvent(Action listener)
    {
        OnDemolishActionHandler -= listener;
    }
}
