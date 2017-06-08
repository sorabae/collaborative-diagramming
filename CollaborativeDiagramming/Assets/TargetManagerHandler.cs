using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetManagerHandler : MonoBehaviour
{
    // Use this for initialization
    private TrackableBehaviour tb;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RegisterBookmark(GameObject augmentation)
    {
        if (tb != null)
        {
            tb.SendMessage("RegisterBookmarkToTarget", augmentation);
        }
    }

    void FixObject(GameObject augmentation)
    {
        if (tb != null)
        {
            tb.SendMessage("FixAugmentation");
        }
    }

    void RegisterCurrentTrackable(TrackableBehaviour current)
    {
        tb = current;
    }
}
