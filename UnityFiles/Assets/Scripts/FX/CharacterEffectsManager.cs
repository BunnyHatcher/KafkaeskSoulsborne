using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;


public class CharacterEffectsManager : MonoBehaviour
{
    
    [SerializeField]Health scriptHealth;
    
    // REFACTORING ADVICE: WHY NOT USE ACCESS MODIFIER PROTECTED?
    [Header("WeaponFX")]
    public WeaponEffects WeaponFX;
    
    [Header("Impact FX")]
    public GameObject[] bloodFX;
    public GameObject shieldBlockFX;

    [Header("Impact Audio")]
    public AudioClip[] weaponImpactSFX;
    public AudioClip[] shieldBlockSFX;





    private void Awake()
    {
        
    }

    

    public virtual void PlayWeaponFX()
    {
        if (WeaponFX != null)
        {
            WeaponFX.PlayWeaponFX();
        }

    }

    /*
    public void ApplyDamage(Vector3 contact)
    {
     Debug.Log("ApplyDamage");

     //assign the direction, for example Physics.Raycast(ray, out hit); direction = hit.normal;
     var direction = contact.normalized;
        
     //calculate angle of blood splatter
     float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 180;

     // trigger BloodFX
     var instance = Instantiate(bloodFX, transform.position, Quaternion.Euler(0, angle + 90, 0));

    // set ground height to enable decals on ground
    instance.GetComponent<BFX_BloodSettings>().GroundHeight = 0f; 

    }
    */


    public void PlayBloodFX()
    {
        //Debug.Log("BloodFX played");
        
        // get bool isInvulnerable and use it to create if condition for shield block effects
        if (scriptHealth.isInvulnerable == true )
        {
            // Debug.Log("ShieldFX played");

            GameObject shield = GameObject.Find("Shield");

            // trigger ShieldBlockFX
            var instance = Instantiate(shieldBlockFX, shield.transform.position, Quaternion.identity);

        }

        else
        { 
            GameObject weapon = GameObject.Find("WeaponLogic");
            // trigger BloodFX
            var instance = Instantiate(bloodFX[Random.Range(0, bloodFX.Length)], weapon.transform.position, Quaternion.identity);

        }
        
        


    }

    




        //play weapon impact audio
        public void PlayWeaponImpactAudio()
    {
        if (scriptHealth.isInvulnerable == true)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = shieldBlockSFX[Random.Range(0, shieldBlockSFX.Length)];
            audioSource.PlayOneShot(audioSource.clip);

        }
        
        else
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = weaponImpactSFX[Random.Range(0, weaponImpactSFX.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }




    





}
