using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public int nbSceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ViveTracker")
        {
            SceneManager.LoadScene(nbSceneToLoad);
        }
    }
}
