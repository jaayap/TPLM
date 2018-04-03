using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour {

    public SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device device;
    public float throwSpeed = 2.0f;

    // Use this for initialization 
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame 
    void Update()
    {
        device = SteamVR_Controller.Input((int) trackedObject.index);
    }

    void OnTriggerStay(Collider col)
    {
      if (col.tag == "SepiaCube")
      {
          if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
          {
              col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
              col.gameObject.transform.SetParent(gameObject.transform);
          }
          if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
          {
              col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
              col.gameObject.transform.SetParent(null);              
          }
      }
}
}
