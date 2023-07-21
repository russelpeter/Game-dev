using System;
using System.Collections;
using System.Collections.Generic;
// using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // delegates to inform action was performed
    private Action OnBuildAreaHandler;
    private Action OnCancelActionHandler;


    public Button buildResidentialAreaBtn;
    public Button cancelActionBtn;
    public GameObject cancelActionPanel;

    // Start is called before the first frame update
    void Start()
    {
        // hide cancelActPanel at game start
        cancelActionPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelActionCallback);;
    }

   // call events when buttons are actually pressed
    private void OnBuildAreaCallback()
    {
        cancelActionPanel.SetActive(true);// show panel
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
}
