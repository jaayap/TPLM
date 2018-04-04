using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerSepia : MonoBehaviour {

    public enum State
    {
        unAugmented,
        augmented,
        endGame
    }

    public State state;

    public Text tutoText;
    public RaycastCamera rayCam;
    public Transform[] cubes;
    public Transform[] spawns;

    public bool red = false;
    public bool green = false;
    public bool blue = false;

    private bool isActive = false;

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
            if(red == true && green == true && blue == true && isActive == false)
            {
                isActive = true;
                tutoText.text = "You grab cubes in different locations but you could not be sure of your choices.";
                tutoText.text += " We will make some changes to help you ";
                //"Vous avez mis chaque cube dans un emplacement mais vous n'aviez aucun moyen d'être
                //sûr de vos choix. Nous allons procédé a quelques modifications pour vous aider.";
                Invoke("ChangeStateToAugmented", 10f);
            }
        }

        else if(state == State.augmented)
        {

            tutoText.text = "We have modified your hearing. Now, you can hear colors. Blue correspond to the sound of water, Green to the sound of tree and Red, the sound of fire";
            //"Nous avons modifié votre ouïe. Maintenant vous pouvez entendre les couleurs. Le bleu correspond au son de l'eau, le vert à celui des feuilles et le rouge à celui du feu.";
            if (red == true && green == true && blue == true && isActive == false)
            {
                isActive = true;
                Invoke("ChangeStateToEndGame", 3f);
            }
        }

        else if(state == State.endGame)
        {
            tutoText.text = "Congratulation ! \n You have successfully completed the exercise !";// "Félicitation! \n Vous avez réussi l'exercice!";
            
            if(isActive == false)
            {
                isActive = true;
                Invoke("ReturnLobby", 3f);
            }
            
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
        isActive = false;
    }

    void ChangeStateToEndGame()
    {
        state = State.endGame;
        isActive = false;
    }
    
    void ReturnLobby()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator StartTuto()
    {
        tutoText.text = "";

        yield return new WaitForSeconds(1f);

        tutoText.text = "Good morning !";//"Bonjour";
        
        yield return new WaitForSeconds(5f);

        tutoText.text = "You are in the shoes of a color-blind. You have to place each cube in each matching location";
            //"Vous êtes dans la peau d'un daltonien. Vous devez mettre chaque cube dans l'emplacement correspondant a sa couleur.";
    }
}
