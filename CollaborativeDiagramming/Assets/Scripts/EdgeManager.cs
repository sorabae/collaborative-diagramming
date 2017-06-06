using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private GameObject fromObject;
    private GameObject toObject;
    private LineRenderer lr;
    void OnConnectedToComponents(GameObject[] connection)
    {
        Debug.Log("OnConnectedToComponenets");
        fromObject = connection[0];
        toObject = connection[1];
        lr = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate () {
        if (lr != null)
        {
            Debug.Log("LateUpdate");
            lr.startWidth = 0.03f;
            lr.endWidth = 0.03f;

            lr.positionCount = 2;
          
            lr.SetPosition(0, fromObject.transform.position);
            lr.SetPosition(1, toObject.transform.position);
        }
    }
}
