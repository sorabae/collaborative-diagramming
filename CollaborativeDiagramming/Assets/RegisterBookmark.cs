using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterBookmark : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void OnSelect()
    {
        GameObject tm = GameObject.Find("TargetManager");
        tm.SendMessage("RegisterBookmark", gameObject.transform.parent.gameObject);
    }
}
