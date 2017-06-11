using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class CubeManager : MonoBehaviour {

    public static CubeManager Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }
    RaycastHit hitInfo;
    GestureRecognizer recognizer;
    public bool manipulating;

    // Use this for initialization
    void Start () {

        Instance = this;
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
            }
        };

        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update() {

        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;

            if(FocusedObject != null)
            {
                getMenuItem();
            }

        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

}

    public void getMenuItem()
    {
        FocusedObject = hitInfo.collider.gameObject;

        
        if (FocusedObject.transform.parent.name == "Cube")
        {
            /*
             Back side chosen -> Attachment
             Bottom side chosen -> Bookmark
             Front side chosen -> Change color
             Left side chosen -> Draw edge
             Right side chosen -> Remove node
             Top side chosen -> Add node
            */
            FocusedObject.SendMessageUpwards(FocusedObject.name + "SideChosen");
            manipulating = true;
        }

        else
        {
            manipulating = false;
        }
        
    }

}
