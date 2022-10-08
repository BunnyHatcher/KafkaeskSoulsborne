using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectsManager : CharacterEffectsManager
{
    
    [SerializeField] private Health playerHealth;
    
    // Set HealthBar to max health on start
    private void Start()
    {
        //playerHealth.GetHealthValue();
        //playerHealth.SetHealthValue(100);


         
    }

    public void DiminishHealthbar()
    {
                
        //playerHealthbar.SetHealth(health);

    }
    



}
