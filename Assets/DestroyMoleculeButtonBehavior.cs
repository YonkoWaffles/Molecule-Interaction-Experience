using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMoleculeButtonBehavior : MonoBehaviour
{
    ModelDeleter _parent;
    [HideInInspector] public int referenceNum = 0;

    public void SetCanvasParent (ModelDeleter md)
    {
        _parent = md;
    }

    public void ButtonPressed ()
    {
        _parent.NewDestroyCandidate(referenceNum);
    }
}
