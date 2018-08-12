using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour {

    public float maxStam { get; set; }
    public float curStam { get; set; }
    public float regenStam;

    public Slider StaminaBar;

    // Use this for initialization

    void Start () {

        maxStam = 100f;
        curStam = maxStam;
        regenStam = 0.5f;

    }
	
	// Update is called once per frame
	void Update () {

        StaminaBar.value = curStam;

    }

    public void DrainStamina(float staminaLost)
    {
        curStam -= staminaLost;

        if (curStam <= 0)
        {
           
        }
    }
    public void RegenStamina(float staminaGain)
    {
        curStam += staminaGain;

        if (curStam > maxStam)
        {
            curStam = maxStam;
        }
    }
    
}
