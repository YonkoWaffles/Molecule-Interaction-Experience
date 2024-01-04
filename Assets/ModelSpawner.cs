using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using Unity.VisualScripting;

public class ModelSpawner : MonoBehaviour
{
    public Image thumbnail;
    public TextMeshProUGUI descriptorText;
    public Transform spawnPoint;
    public float spawnOffset = 3f;
    public bool useSpawnPoint = true;

    Object[] allModels;
    List<Sprite> allModelImgs = new List<Sprite>();
    List<string> allModelNames = new List<string>();
    int currentModelInt = 0;

    Transform playerGO;

    //List<UnityEngine.XR.InputDevice> rightHandedControllers = new List<UnityEngine.XR.InputDevice>();

    private void Awake()
    {
        //var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        //UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, rightHandedControllers);

        allModels = Resources.LoadAll("MoleculeModels", typeof(GameObject));

        foreach (Object index in allModels)
        {
            allModelImgs.Add(index.GetComponent<Mol_ID>().molImg);
            allModelNames.Add(index.GetComponent<Mol_ID>().molName);
        }

        thumbnail.sprite = (Sprite)allModelImgs[currentModelInt];
        descriptorText.text = allModelNames[currentModelInt];
    }

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //bool triggerValue;
        //if (rightHandedControllers.Count <= 0)
        //    return;

        //if (rightHandedControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        //{
        //    Debug.Log("Trigger button is pressed.");
        //}

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnButtonPressed();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            NextButtonPressed(true);
        }
    }

    public void NextButtonPressed (bool isNext)
    {
        if (isNext)
        {
            currentModelInt++;
            if (currentModelInt > allModelImgs.Count - 1)
                currentModelInt = 0;

            thumbnail.sprite = (Sprite)allModelImgs[currentModelInt];
            descriptorText.text = allModelNames[currentModelInt];
        }
        else
        {
            currentModelInt--;
            if (currentModelInt < 0)
                currentModelInt = allModelImgs.Count - 1;

            thumbnail.sprite = (Sprite)allModelImgs[currentModelInt];
            descriptorText.text = allModelNames[currentModelInt];
        }
    }

    public void SpawnButtonPressed ()
    {
        if (allModels[currentModelInt] != null)
        {
            if (useSpawnPoint)
            {
                Instantiate(allModels[currentModelInt], spawnPoint.position, Quaternion.identity);
            }
            else
            {
                Vector3 inFront = new Vector3(playerGO.position.x, 1, playerGO.position.z + spawnOffset);
                Instantiate(allModels[currentModelInt], inFront, Quaternion.identity);
            }
        }
    }
}
