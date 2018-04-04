using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodiePlaying : MonoBehaviour {

    public Color[] partition01;
    public Color[] partition02;
    //public Color[] partition03;
    //public Color[] partition04;

    public bool partitionFinish = false;
    public float waitingTime = 5;
    public GameObject particleSound;
    public GameObject particleTreeSound;

    public Transform positionToInstantiate;

    public int nbPartitionToPlay = 1;

    private List<Color> partitionPlayed;

    // Use this for initialization
    void Start() {
        partitionPlayed = new List<Color>();
        StartCoroutine(playMelody01());
    }

    public void AddColorTopartitionPlayed(Color colorPlayed, Vector3 hitPosition)
    {
        if (nbPartitionToPlay == 1)
        {
            if(partitionPlayed.Count -1 < partition01.Length - 1)
            {
                partitionPlayed.Add(colorPlayed);
            }

            if (!isGood(colorPlayed, partition01[partitionPlayed.Count - 1])){
                CreateParticuleColored(Color.white, hitPosition,particleTreeSound);
                partitionPlayed.Clear();
            }
            else
            {
                CreateParticuleColored(colorPlayed, hitPosition, particleSound);
            }

            if (partitionPlayed.Count == partition01.Length)
            {
                partitionFinish = true;
                StopAllCoroutines();
                partitionFinish = false;
                nbPartitionToPlay++;
                StartCoroutine(playMelody02());
            }
        }
        else if (nbPartitionToPlay == 2)
        {
            if (partitionPlayed.Count - 1 < partition02.Length - 1)
            {
                partitionPlayed.Add(colorPlayed);
            }

            if (!isGood(colorPlayed, partition02[partitionPlayed.Count - 1]))
            {
                CreateParticuleColored(Color.white, hitPosition, particleTreeSound);
                partitionPlayed.Clear();
            }
            else
            {
                CreateParticuleColored(colorPlayed, hitPosition, particleSound);
            }

            if (partitionPlayed.Count == partition02.Length)
            {
                partitionFinish = true;
                StopAllCoroutines();
                partitionFinish = false;
                nbPartitionToPlay++;
                //StartCoroutine(playMelody03());
                ReturnToMenu();
            }
        }
        //else if (nbPartitionToPlay == 3)
        //{
        //    if (partitionPlayed.Count - 1 < partition03.Length - 1)
        //    {
        //        partitionPlayed.Add(colorPlayed);
        //    }

        //    if (!isGood(colorPlayed, partition03[partitionPlayed.Count - 1]))
        //    {
        //        CreateParticuleColored(Color.white, hitPosition, particleTreeSound);
        //        partitionPlayed.Clear();
        //    }
        //    else
        //    {
        //        CreateParticuleColored(Color.white, hitPosition, particleSound);
        //    }

        //    if (partitionPlayed.Count == partition03.Length)
        //    {
        //        partitionFinish = true;
        //        StopAllCoroutines();
        //        partitionFinish = false;
        //        nbPartitionToPlay++;
        //        StartCoroutine(playMelody04());
        //    }
        //}
        //else if (nbPartitionToPlay == 4)
        //{
        //    if (partitionPlayed.Count - 1 < partition04.Length - 1)
        //    {
        //        partitionPlayed.Add(colorPlayed);
        //    }

        //    if (!isGood(colorPlayed, partition04[partitionPlayed.Count - 1]))
        //    {
        //        CreateParticuleColored(Color.white, hitPosition, particleTreeSound);
        //        partitionPlayed.Clear();
        //    }
        //    else
        //    {
        //        CreateParticuleColored(Color.white, hitPosition, particleSound);
        //    }

        //    if (partitionPlayed.Count == partition04.Length)
        //    {
        //        partitionFinish = true;
        //        StopAllCoroutines();
        //        partitionFinish = false;
        //        nbPartitionToPlay++;
        //    }
        //}

    }

    public void ReturnToMenu()
    {
        //LoadMenu
        Application.Quit();
    }

    bool isGood(Color colorPlayed, Color colorToPlay)
    {
        Debug.Log(colorPlayed +" / " + colorToPlay);
        if(colorPlayed == colorToPlay)
            return true;
        else
            return false;
    }

    private void Update()
    {
        if(partitionFinish == true)
        {
            StopAllCoroutines();
            if(nbPartitionToPlay == 4)
            {
                return;
            }
            else
            {
                partitionFinish = false;

                nbPartitionToPlay++;
                if(nbPartitionToPlay == 2)
                    StartCoroutine(playMelody02());
                //else if (nbPartitionToPlay == 3)
                //    StartCoroutine(playMelody03());
                //else if (nbPartitionToPlay == 4)
                //    StartCoroutine(playMelody04());

            }
        }
    }

    void CreateParticuleColored(Color color, Vector3 position, GameObject particle)
    {
        ParticleSystem[] allPS = particle.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem itemPS in allPS)
        {
            itemPS.startColor = new Color(color.r, color.g, color.b, 255);
            if (itemPS.GetComponent<Material>())
            {
                itemPS.GetComponent<Material>().color = color;
            }
        }
        GameObject go = Instantiate(particle);
        go.transform.position = position;
        Light light = go.GetComponentInChildren<Light>();
        if (light)
        {
            Destroy(light.gameObject, 6f);
        }
        Destroy(go, 15f);
    }

    IEnumerator playMelody01()
    {
        int i = 0;
        while (partitionFinish == false)
        {
            if(i == partition01.Length)
            {
                i = 0;
            }
            CreateParticuleColored(partition01[i], positionToInstantiate.position,particleSound);
            if(i == partition01.Length)
            {
                yield return new WaitForSeconds(waitingTime + waitingTime);
            }
            else
            {
                i++;
                yield return new WaitForSeconds(waitingTime);
            }
        }
    }

    IEnumerator playMelody02()
    {
        int i = 0;
        while (partitionFinish == false)
        {
            if (i == partition02.Length)
            {
                i = 0;
            }
            CreateParticuleColored(partition02[i], positionToInstantiate.position, particleSound);
            if (i == partition02.Length)
            {
                yield return new WaitForSeconds(waitingTime + waitingTime);
            }
            else
            {
                i++;
                yield return new WaitForSeconds(waitingTime);
            }
        }
    }

    //IEnumerator playMelody03()
    //{
    //    int i = 0;
    //    while (partitionFinish == false)
    //    {
    //        if (i == partition03.Length)
    //        {
    //            i = 0;
    //        }
    //        CreateParticuleColored(partition03[i], positionToInstantiate.position, particleSound);
    //        if (i == partition03.Length)
    //        {
    //            yield return new WaitForSeconds(waitingTime + waitingTime);
    //        }
    //        else
    //        {
    //            i++;
    //            yield return new WaitForSeconds(waitingTime);
    //        }
    //    }
    //}

    //IEnumerator playMelody04()
    //{
    //    int i = 0;
    //    while (partitionFinish == false)
    //    {
    //        if (i == partition04.Length)
    //        {
    //            i = 0;
    //        }
    //        CreateParticuleColored(partition03[i], positionToInstantiate.position, particleSound);
    //        if (i == partition04.Length)
    //        {
    //            yield return new WaitForSeconds(waitingTime + waitingTime);
    //        }
    //        else
    //        {
    //            i++;
    //            yield return new WaitForSeconds(waitingTime);
    //        }
    //    }
    //}
}
