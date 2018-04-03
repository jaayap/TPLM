using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera : MonoBehaviour {

    public GameObject cubeRed;
    public GameObject cubeGreen;
    public GameObject cubeBlue;

    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 100);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            
            if(hit.collider.name == "CubeRed")
            {
                if (!cubeRed.GetComponent<AudioSource>().isPlaying)
                    cubeRed.GetComponent<AudioSource>().Play();

                cubeGreen.GetComponent<AudioSource>().Stop();
                cubeBlue.GetComponent<AudioSource>().Stop();
            }

            else if (hit.collider.name == "CubeGreen")
            {
                cubeRed.GetComponent<AudioSource>().Stop();

                if (!cubeGreen.GetComponent<AudioSource>().isPlaying)
                    cubeGreen.GetComponent<AudioSource>().Play();

                cubeBlue.GetComponent<AudioSource>().Stop();
            }

            else if (hit.collider.name == "CubeBlue")
            {
                cubeRed.GetComponent<AudioSource>().Stop();
                cubeGreen.GetComponent<AudioSource>().Stop();

                if (!cubeBlue.GetComponent<AudioSource>().isPlaying)
                    cubeBlue.GetComponent<AudioSource>().Play();
            }

            else
            {
                cubeRed.GetComponent<AudioSource>().Stop();
                cubeGreen.GetComponent<AudioSource>().Stop();
                cubeBlue.GetComponent<AudioSource>().Stop();
            }
        }
        else
        {
            cubeRed.GetComponent<AudioSource>().Stop();
            cubeGreen.GetComponent<AudioSource>().Stop();
            cubeBlue.GetComponent<AudioSource>().Stop();
        }

    }
}
