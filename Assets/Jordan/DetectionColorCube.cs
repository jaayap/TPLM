using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionColorCube : MonoBehaviour {

    public enum State
    {
        red,
        green,
        blue,
    }


    public State state;
    public GameManagerSepia manager;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SepiaCube" && manager.state == GameManagerSepia.State.unAugmented)
        {
            if(state == State.red)
            {
                manager.red = true;
            }
            else if(state == State.green)
            {
                manager.green = true;
            }
            else if (state == State.blue)
            {
                manager.blue = true;
            }
        }

        else if (other.tag == "SepiaCube" && manager.state == GameManagerSepia.State.augmented)
        {
            if (state == State.red && other.GetComponent<Renderer>().material.name == "Red (Instance)")
            {
                manager.red = true;
            }
            else if (state == State.green && other.GetComponent<Renderer>().material.name == "Green (Instance)")
            {
                manager.green = true;
            }
            else if (state == State.blue && other.GetComponent<Renderer>().material.name == "Blue (Instance)")
            {
                manager.blue = true;
            }
        }
    }
}
