using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRUIP;

public class ModelDeleter : MonoBehaviour
{
    public GameObject modelDeleteButtonPrefab;
    public Transform vlg;

    List<GameObject> allSpawnedModels = new List<GameObject>();
    int savedRefNum = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            RefreshList();
        if (Input.GetKeyDown(KeyCode.K))
            DestroyButtonPressed();
    }

    // model was selected for kill
    public void NewDestroyCandidate(int referenceNum)
    {
        savedRefNum = referenceNum;
    }

    // Kill model
    public void DestroyButtonPressed()
    {
        // Make sure it exists first
        if (allSpawnedModels[savedRefNum])
            Destroy(allSpawnedModels[savedRefNum]);

        RefreshList();
    }

    // Refresh button list
    public void RefreshList()
    {
        Debug.Log("Refresh");

        //Get all the children of vlg and kill all of them to erase the buttons
        List<GameObject> tempChildren = new List<GameObject>();
        for (int i = 0; i < vlg.transform.childCount; i++)
        {
            tempChildren.Add(vlg.transform.GetChild(i).gameObject);
        }
        foreach (GameObject j in tempChildren)
        {
            //Debug.Log(j.name);
            Destroy(j);
        }

        // Find all the models in the scene
        GameObject[] modelGOArray = GameObject.FindGameObjectsWithTag("Model");

        // Reset the list
        allSpawnedModels.Clear();

        // Convert array to list
        foreach (GameObject index in modelGOArray)
        {
            allSpawnedModels.Add(index);
        }

        // Loop through the spawned models
        for (int g = 0; g < allSpawnedModels.Count; g++)
        {
            // Get the identity for the names
            Mol_ID _identity = allSpawnedModels[g].GetComponent<Mol_ID>();

            //Spawn new button
            GameObject newButton = Instantiate(modelDeleteButtonPrefab, vlg);

            //Debug.Log(_identity.name);

            // Update the button's text
            newButton.GetComponent<VRUIP.ButtonController>().text = _identity.molName;
            newButton.GetComponent<VRUIP.ButtonController>().UpdateTextField();

            // Set DMBB with references so it can call back on press
            newButton.GetComponent<DestroyMoleculeButtonBehavior>().SetCanvasParent(this);
            newButton.GetComponent<DestroyMoleculeButtonBehavior>().referenceNum = g; 
        }
    }
}
