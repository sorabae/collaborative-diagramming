/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// This class serves both as an augmentation definition for an ImageTarget in the editor
    /// as well as a tracked image target result at runtime
    /// </summary>
    public class ImageTargetBehaviour : ImageTargetAbstractBehaviour
    {
        private GameObject tm;
        private Transform augmentation;
        private bool fix;

        // Use this for initialization
        void Start()
        {
            tm = GameObject.Find("TargetManager");

            if (this.name == "BookTarget")
            {
                GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>();
                foreach (GameObject obj in objs)
                {
                    if (obj.name == "Cube")
                    {
                        augmentation = obj.transform; //transform.Find ("Cube").transform;
                        obj.SetActive(true);
                    }
                }

            }
        }

        public void RegisterBookmarkToTarget(GameObject obj)
        {
            Debug.Log("RegisterBookmarkToTarget");
            augmentation = obj.transform;
        }
        public void FixAugmentation()
        {
            Debug.Log("Fix Augmentation");
            fix = true;
        }

        override public void OnTrackerUpdate(TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        private void OnTrackingFound()
        {
            Debug.Log(this.name + ", OnTrackingFound");
            Debug.Log(augmentation + " and " + fix);
            tm.SendMessage("RegisterCurrentTrackable", this);
            if (augmentation != null)
            {
                if (!fix)
                {
                    augmentation.position = transform.position;
                }
            }
        }

        private void OnTrackingLost()
        {
            //augmentation.position = this.transform.position;
        }
    }
}
