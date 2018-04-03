using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormesPlacement : MonoBehaviour {

    public static int nbForme = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(nbForme == 5)
        {
            Debug.Log("reussi");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == this.name)
        {
            nbForme++;
            Destroy(other.gameObject,2);
        }
          
    }
}
