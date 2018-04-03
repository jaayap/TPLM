using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodiePlaying : MonoBehaviour {

    public GameObject[] notes;
    
	// Use this for initialization
	public IEnumerator PlayMelodie () {
        yield return new WaitForSeconds(0);
	}

    //public ActivateNote()
    //{

    //}
}
