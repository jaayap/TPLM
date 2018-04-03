using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manette : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XyloBlock>())
        {
            Vector3 position = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            other.GetComponent<XyloBlock>().ActivateColorSound(position);
        }
    }
}
