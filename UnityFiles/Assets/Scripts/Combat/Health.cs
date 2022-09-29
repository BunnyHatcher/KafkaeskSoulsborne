using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    protected int health;
    private bool isInvulnerable = false;

    public event Action OnTakeDamage; //event to be invoked whenever player or enemy takes damage
    public event Action OnDie; // event to be invoked whenever player or enemy dies

    public bool IsDead => health == 0; //short mway to check anywhere else if IsDead is true and returning if health is 0 

    protected void Start()
    {
        health = maxHealth; 
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;

    }

    public void DealDamage(int damage)
    {
        if(health <= 0) { return; }

        if(isInvulnerable) { return; } // cancel calculation if invulnerability is turned on

        health = Mathf.Max(health - damage, 0); // returns either current health value or 0 if it goes below 0

        OnTakeDamage?.Invoke(); // invoke event when damage is dealt

        //play pain audio
        FindObjectOfType<AudioManager>().Play("PlayerPain");
        
        
        if(health == 0)
        {

            //play death audio
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            OnDie?.Invoke(); // invoke event when death has taken his toll

        }

        Debug.Log(health);
    }

    
}
