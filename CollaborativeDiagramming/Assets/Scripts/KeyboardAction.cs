using UnityEngine;

public class KeyboardAction : MonoBehaviour {
    //TouchScreenKeyboard keyboard;
    //public static string keyboardText = "";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (keyboard != null && keyboard.active == false)
        {
            if (keyboard.done == true)
            {
                keyboardText = keyboard.text;
                gameObject.transform.parent.GetComponentInChildren<TextMesh> ().text = keyboardText;
                keyboard = null;
            }
        }*/
    }

    void OnSelect()
    {
        Debug.Log("keyboardSet");
        KeyboardMain km = Resources.FindObjectsOfTypeAll<KeyboardMain>()[0];
        //km.gameObject.SetActive(true);
        km.InputDisplay = transform.parent.FindChild("Text").gameObject;
        km.OnStart(transform.parent);
        //keyboard = new TouchScreenKeyboard("Sample text that goes into the textbox", TouchScreenKeyboardType.Default, false, false, false, false, "sample prompting text that goes above the textbox");
    }
}
