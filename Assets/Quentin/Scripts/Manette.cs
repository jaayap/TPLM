using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manette : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XyloBlock>())
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, transform.localScale.x);
            other.GetComponent<XyloBlock>().ActivateColorSound(hitColliders[0].transform.position);
        }
    }
}
