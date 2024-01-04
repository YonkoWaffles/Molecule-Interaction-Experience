using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject nodeDataUI;
    public GameObject interactionMenuUI;

    public InputActionProperty showMenu;

    // Update is called once per frame
    void Update()
    {
        if (showMenu.action.WasPressedThisFrame())
        {
            interactionMenuUI.SetActive(!interactionMenuUI.activeSelf);
        } 
    }
    // When player presses right trigger, deselect current node
    void HideDate()
    {

    }
    // When player presses right trigger, deselect current node and hide UI
    void HideData()
    {
        nodeDataUI.SetActive(false);
    }
    void updateDataToCurrentNode()
    {

    }
}
