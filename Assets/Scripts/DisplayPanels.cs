using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayPanels : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;

    private GameObject activePanel;
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;


    private void SetSelection(GameObject panelToSetSelected)
    {

        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
            activePanelMenuObject.SetFirstSelected();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSelection(menuPanel);
    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
        //optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        SetSelection(optionsPanel);

    }

    //Call this function to deactivate and hide the Options panel during the main menu
    public void HideOptionsPanel()
    {
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        //optionsTint.SetActive(false);
    }

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        SetSelection(menuPanel);
    }

    //Call this function to deactivate and hide the main menu panel during the main menu
    public void HideMenu()
    {
        menuPanel.SetActive(false);

    }
}
