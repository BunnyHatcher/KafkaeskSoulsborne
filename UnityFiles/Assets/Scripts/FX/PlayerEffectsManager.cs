using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectsManager : CharacterEffectsManager
{

    // Set HealthBar to current health

   
    public void CalculatePlayerHealth()
    {
        Health healthScript = GetComponent<Health>();
        
        PlayerHealthbar playerHealthbar = GetComponent<PlayerHealthbar>();
        
        //playerHealthbar.SetHealth(health);

    }
    



}
