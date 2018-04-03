using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSepia : MonoBehaviour {


    public enum State
    {
        unAugmented,
        augmented
    }


    public State state;

    public Text tutoText;
    public RaycastCamera rayCam;
    public Transform[] cubes;
    public Transform[] spawns;

    public bool red = false;
    public bool green = false;
    public bool blue = false;

    // Use this for initialization
    void Start () {

        state = State.unAugmented;
        StartCoroutine(StartTuto());

	}
	
	// Update is called once per frame
	void Update () {
		
        if(state == State.unAugmented)
        {
            // activé le tuto / explication
            
            // attendre les cubes
            //Passer  l'étape suivante
            if(red == true && green == true && blue == true)
            {
                tutoText.text = "Vous avez mis chaque cube dans un emplacement mais vous n'avez aucun moyen d'être sûr de vos choix. Nous allons procédé a quelques modifications pour vous aider.";
                Invoke("ChangeStateToAugmented", 10f);
            }
        }

        else if(state == State.augmented)
        {

            tutoText.text = "Nous avons modifié votre ouïes. Maintenant vous pouvez entendre les couleurs. Le bleu correspond au son de l'eau, le vert à celui des feuilles et le rouge à celui du feu.";
        }


    }

    void ChangeStateToAugmented()
    {        
        state = State.augmented;
        //Fade

        //respawn des cubes
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].position = spawns[i].position;
        }

        //activer l'audio source du cube regardé
        rayCam.enabled = true;

        //reset bool
        red = false;
        green = false;
        blue = false;
    }

    IEnumerator StartTuto()
    {
        tutoText.text = "";

        yield return new WaitForSeconds(1f);

        tutoText.text = "Bonjour";
        
        yield return new WaitForSeconds(5f);

        tutoText.text = "Vous êtes dans la peau d'un daltonien. Vous devez mettre chaque cube dans l'emplacement correspondant a sa couleur.";
    }
}
