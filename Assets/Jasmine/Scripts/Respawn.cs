using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject formes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(
                other.tag == "square"
                || other.tag == "star"
                || other.tag == "Rond"
                || other.tag == "Triangle"
                || other.tag == "heart"
            )
        {
            other.gameObject.transform.position = formes.transform.position;
        }
    }
}
