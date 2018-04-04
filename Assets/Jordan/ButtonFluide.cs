using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFluide : MonoBehaviour {

    public FluideTemp fluideTemp;

    public enum FluideTemperature
    {
        chaud,
        froid
    }

    public FluideTemperature temp;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Hand")
        {
            if(temp == FluideTemperature.froid)
                fluideTemp.quantiteLiquideFroid += Time.deltaTime;
            else if(temp == FluideTemperature.chaud)
                fluideTemp.quantiteLiquideChaud += Time.deltaTime;
        }
    }
}
