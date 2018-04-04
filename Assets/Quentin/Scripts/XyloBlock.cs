using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XyloBlock : MonoBehaviour {

    Color color;
    bool isTouched = false;
    public GameObject particleSound;
    //Fonction
	public void ActivateColorSound(Vector3 position)
    {
        if (!isTouched)
        {
            Debug.Log("touch");
            color = GetComponent<Renderer>().sharedMaterial.color;
            FindObjectOfType<MelodiePlaying>().AddColorTopartitionPlayed(color, position);
            isTouched = true;
            Invoke("RemoveIsTouched", 5f);
        }
    }

    void RemoveIsTouched()
    {
        isTouched = false;
    }
}
