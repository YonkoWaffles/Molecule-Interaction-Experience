using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UIManagerNew : MonoBehaviour
{
    public GameObject nodeDataUI;
    public TextMeshProUGUI nodeDataText;
    public InputActionProperty showMenu;


    // When player presses right trigger, deselect current node
    public void ShowData(Text dataString)
    {
        UpdateDataToCurrentNode(dataString.text);
        nodeDataUI.SetActive(true);
    }
    // When player presses right trigger, deselect current node and hide UI
    public void HideData()
    {
        nodeDataUI.SetActive(false);
    }

    public void UpdateDataToCurrentNode(string dataString)
    {
        nodeDataText.text = "Subnode Data:\n" + dataString;
    }
}
