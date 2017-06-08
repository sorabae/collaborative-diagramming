//Author and copyright owner: Matrix Inception Inc.
//HoloLens D3D Keyboard v1.3
//Date: 2017-02-22
//This script controls higher level functions of the keyboard, namely Shift, Show / Hide, and Move / Pin.

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;

public class KeyboardMain : MonoBehaviour {

    public GameObject InputDisplay;
    public bool ShiftOn;
    public bool IsDone;
    public GameObject keyboardUpper;
    public GameObject keyboardLower;
    public GameObject keyboardSet;
    public GameObject keyDone;
    public bool IsMoving;
    public AudioClip[] keySounds;
    int noteCount = 0;

    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start () {
        keyboardUpper.SetActive(ShiftOn);
        keyboardLower.SetActive(!ShiftOn);
        gameObject.SetActive(false);

        /*keywords.Add("Move Keyboard", () =>
            {
                IsMoving = true;
            }
        );


        keywords.Add("Pin Keyboard", () =>
            {
                IsMoving = false;
            }
        );

        keywords.Add("Scale Up Keyboard", () =>
        {
            transform.localScale *= 1.1f;
        }
        );

        keywords.Add("Scale Down Keyboard", () =>
        {
            transform.localScale /= 1.1f;
        }
        );

        keywords.Add("Leave Note", () =>
        {
            noteCount++;
            GameObject newNote = (GameObject)Object.Instantiate(InputDisplay, InputDisplay.transform.position, InputDisplay.transform.rotation);
            newNote.transform.localScale = new Vector3(newNote.transform.localScale.x*transform.localScale.x, newNote.transform.localScale.y * transform.localScale.y, newNote.transform.localScale.z * transform.localScale.z);
            newNote.name = "Note" + noteCount;
        }
        );

        keywords.Add("Remove Note", () =>
        {
            if ( GazeManager.Instance.HitObject != null && GazeManager.Instance.HitObject != InputDisplay && GazeManager.Instance.HitObject.name.Contains("Note"))
            {
                DestroyImmediate(GazeManager.Instance.HitObject);
            }
        }
        );

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();*/
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsMoving) {
        //    transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position + Camera.main.transform.forward * 1.5f + transform.right * (-0.39f) * transform.localScale.x, 0.1f );
        //    transform.LookAt(Camera.main.transform.position+ Camera.main.transform.forward * 4+ transform.right * (-0.39f)*transform.localScale.x); 
        //}
    }

    public void OnStart(Transform caller)
    {
        gameObject.SetActive(true);

        transform.position = caller.position + new Vector3(0, -0.125f, -0.25f);
        //transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position + Camera.main.transform.forward * 1.5f + transform.right * (-0.39f) * transform.localScale.x, 0.1f);
        //transform.LookAt(Camera.main.transform.position+ Camera.main.transform.forward * 4+ transform.right * (-0.39f)*transform.localScale.x);
    }

    public void OnShift()
    {
        ShiftOn = !ShiftOn;
        keyboardUpper.SetActive(ShiftOn);
        keyboardLower.SetActive(!ShiftOn);
    }

    //The green square is the "Done" key, and it's kept as a separate key from the rest of the keyboard. 
    //Once selected it shows or hides the keyboard. Additional scripts can be added here to submit the message.
    public void OnDone()
    {
        IsDone = !IsDone;
        gameObject.SetActive(!IsDone);
        /*if (IsDone) {
            keyDone.transform.position += keyDone.transform.right * (-(0.726f+0.06f))*transform.localScale.x + keyDone.transform.up * (0.245f+0.1f)* transform.localScale.y;
        }
        else
        {
            keyDone.transform.position += keyDone.transform.right * (0.726f + 0.06f) * transform.localScale.x + keyDone.transform.up * (-(0.245f + 0.1f)) * transform.localScale.y;
        }*/
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
