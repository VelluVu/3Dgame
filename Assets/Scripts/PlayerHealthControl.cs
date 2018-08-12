using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthControl : MonoBehaviour {

    public float maxHealth { get; set; }
	public float curHealth { get; set; }

    public Slider HealthBar;

	// Use this for initialization
	void Start () {
        maxHealth = 100f;
        curHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update () {
        HealthBar.value = curHealth;

    }
    float CalculateHealth()
    {
        return curHealth/ maxHealth;
    }
    public void DealDamage(float damageTaken)
    {
        curHealth -= damageTaken;
        
        if (curHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        curHealth = 0;
        FindObjectOfType<GameController>().EndGame();
        FindObjectOfType<PlayerController>().Die();


    }
}
