using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuObject : MonoBehaviour
{
    public GameObject firstSelected;

    public void SetFirstSelected()
    {
        //Tell the EventSystem to select this object
        EventSystemChecker.menuEventSystem.SetSelectedGameObject(firstSelected);
    }

    public void OnEnable()
    {
        //Check if we have an event system present
        if (EventSystemChecker.menuEventSystem != null)
        {
            //If we do, select the specified object
            SetFirstSelected();
        }

    }

}
