using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class VibrationMyo : MonoBehaviour {


    public GameObject myo = null;
    public FluideTemp fluideTemp;

    
	// Update is called once per frame
	void OnTriggerStay(Collider other) {

        
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (other.tag == "Hand")
        {
            if (fluideTemp.globalTemp < 30)
                thalmicMyo.Vibrate(VibrationType.Short);
            else if (fluideTemp.globalTemp > 30 && fluideTemp.globalTemp < 40)
                thalmicMyo.Vibrate(VibrationType.Medium);
            else if (fluideTemp.globalTemp > 40)
                thalmicMyo.Vibrate(VibrationType.Long);
        } 
    }
}
