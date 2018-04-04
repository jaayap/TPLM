using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class TeleportMyo : MonoBehaviour {

    public GameObject myo = null;
    private Pose _lastPose = Pose.Unknown;
    public FadeDash fd;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            // Access the ThalmicMyo component attached to the Myo game object.
            ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

            if (thalmicMyo.pose != _lastPose)
            {
                _lastPose = thalmicMyo.pose;

                if (thalmicMyo.pose == Pose.Fist)
                {
                    thalmicMyo.Vibrate(VibrationType.Medium);
                    //recuperez point de contact
                    Vector3 positionTP = other.ClosestPointOnBounds(transform.position);
                    //dash
                    fd.DoDashWithTranslation(positionTP);
                }
            }
        }
    }

    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }
        myo.NotifyUserAction();
    }
}