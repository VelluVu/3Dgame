﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaControl : MonoBehaviour {

	float burnDmg = 1f;
    
	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerHealthControl>().DealDamage(burnDmg);
        }
    }
    /*if (collision.gameObject.tag == "Player")
    {
        collision.gameObject.GetComponent<PlayerHealthControl>().DealDamage(burnDmg);
    }*/


}
