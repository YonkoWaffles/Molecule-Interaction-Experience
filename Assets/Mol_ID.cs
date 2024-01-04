using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mol_ID : MonoBehaviour
{
    public string molName = "unnamed";
    public Sprite molImg;

    UIManagerNew dataMan;

    private void Start()
    {
        dataMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManagerNew>();  
    }

    public void SendData(Text dataString)
    {
        dataMan.ShowData(dataString);
    }
}
