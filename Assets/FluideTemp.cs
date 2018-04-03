using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluideTemp : MonoBehaviour {


    public float globalTemp = 0;

    public float quantiteLiquideFroid = 0;
    public float quantiteLiquideChaud = 0;

    private int tempFluideFroid = 20;
    private int tempFluideChaud = 80;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        globalTemp = (quantiteLiquideFroid * tempFluideFroid + quantiteLiquideChaud * tempFluideChaud) / (quantiteLiquideChaud + quantiteLiquideFroid);

	}
}
