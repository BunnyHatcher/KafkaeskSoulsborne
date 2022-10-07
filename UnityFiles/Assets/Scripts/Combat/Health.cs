using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    protected int health;

    public PlayerHealthbar playerHealthbar;

    public bool isInvulnerable = false;

    public event Action OnTakeDamage; //event to be invoked whenever player or enemy takes damage
    public event Action OnDie; // event to be invoked whenever player or enemy dies

    public bool IsDead => health == 0; //short way to check anywhere else if IsDead is true and returning if health is 0 

    //---------E V E N T S----------------------------------------------------------------------------------------

    public UnityEvent damageTakenEvent;


    //-----------------------------------------------------------------------------------------------------


    protected void Start()
    {
        // at the start - don't forget to set the player's healt as well as his healthbar to max value
        health = maxHealth;
        playerHealthbar.SetMaxHealth(maxHealth);
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;

    }

    public void DealDamage(int damage)
    {
        if(health <= 0) { return; }

        if(isInvulnerable)  // cancel calculation if invulnerability is turned on
        {
            return;
        }

        health = Mathf.Max(health - damage, 0); // returns either current health value or 0 if it goes below 0

        OnTakeDamage?.Invoke(); // invoke event when damage is dealt

        //Invoke Events when taking damage -  why not using the OnTakeDamage Invoke from above? Well, it seems like that is another kind of event, an Action, not a Unity event
        damageTakenEvent.Invoke();

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
