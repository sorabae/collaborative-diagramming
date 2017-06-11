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
    KeyboardAction keyboard;
    RegisterBookmark bookmark;
    PlusAction plus;

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

        
        if (FocusedObject == GameObject.Find("Front"))
        {
            keyboard = new KeyboardAction();
            keyboard.OnSelect();
        }

        if (FocusedObject == GameObject.Find("Left"))
        {
            bookmark = new RegisterBookmark();
            bookmark.OnSelect();
        }
        if(FocusedObject == GameObject.Find("Right"))
        {
            plus = new PlusAction();
            plus.OnSelect();
        }

        else
        {
            manipulating = false;
        }
        
    }

}
