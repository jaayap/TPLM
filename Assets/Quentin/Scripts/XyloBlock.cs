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
        ParticleSystem[] allPS = particleSound.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem itemPS in allPS)
        {
            //if(itemPS.colorOverLifetime.enabled == true)
            //{
            //    itemPS.colorOverLifetime.color = color;
            //}
            itemPS.startColor = color;
            if (itemPS.GetComponent<Material>())
            {
                itemPS.GetComponent<Material>().color = color;
            }
        }
        GameObject go = Instantiate(particleSound);
        go.transform.position = position;
        Light light = go.GetComponentInChildren<Light>();
        if (light)
        {
            Destroy(light.gameObject, 6f); 
        }
        Destroy(go, 15f);
    }
}
