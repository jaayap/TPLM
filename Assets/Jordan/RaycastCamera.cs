using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera : MonoBehaviour {

    public GameObject cubeRed;
    public GameObject cubeGreen;
    public GameObject cubeBlue;
    
    public AudioSource ambiantSound;

    public float focusVolume = 1f;
    public float unfocusVolume = 0.5f;


    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 100);
        if (Physics.SphereCast(transform.position, 0.02f,transform.forward, out hit))
        {
            
            if(hit.collider.name == "CubeRed")
            {
                cubeRed.GetComponent<AudioSource>().volume = focusVolume;
                

                cubeGreen.GetComponent<AudioSource>().volume = unfocusVolume;
                cubeBlue.GetComponent<AudioSource>().volume = unfocusVolume;

                ambiantSound.volume = 0.3f;
            }

            else if (hit.collider.name == "CubeGreen")
            {
                cubeRed.GetComponent<AudioSource>().volume = unfocusVolume;

                
                cubeGreen.GetComponent<AudioSource>().volume = focusVolume;
                

                cubeBlue.GetComponent<AudioSource>().volume = unfocusVolume;

                ambiantSound.volume = 0.3f;
            }

            else if (hit.collider.name == "CubeBlue")
            {
                cubeRed.GetComponent<AudioSource>().volume = unfocusVolume;
                cubeGreen.GetComponent<AudioSource>().volume = unfocusVolume;

                cubeBlue.GetComponent<AudioSource>().volume = focusVolume;

                ambiantSound.volume = 0.3f;
            }

            else
            {
                cubeRed.GetComponent<AudioSource>().volume = unfocusVolume;
                cubeGreen.GetComponent<AudioSource>().volume = unfocusVolume;
                cubeBlue.GetComponent<AudioSource>().volume = unfocusVolume;

                ambiantSound.volume = 1f;
            }
        }
        else
        {
            cubeRed.GetComponent<AudioSource>().volume = unfocusVolume;
            cubeGreen.GetComponent<AudioSource>().volume = unfocusVolume;
            cubeBlue.GetComponent<AudioSource>().volume = unfocusVolume;

            ambiantSound.volume = 1f;
        }

    }
}
