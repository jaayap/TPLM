using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XyloBlock : MonoBehaviour {

    Color color;
    public GameObject particleSound;
    //Fonction
	public void ActivateColorSound(Vector3 position)
    {
        Debug.Log("touch");
        color = GetComponent<Renderer>().sharedMaterial.color;
        FindObjectOfType<MelodiePlaying>().AddColorTopartitionPlayed(color,position);
    }
}
