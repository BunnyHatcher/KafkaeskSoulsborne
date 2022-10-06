using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;


public class CharacterEffectsManager : MonoBehaviour
{

    [Header("WeaponFX")]
    public WeaponEffects WeaponFX;
    
    [Header("Damage FX")]
    public GameObject[] bloodFX;

    [Header("Weapon Impact SFX")]
    public AudioClip[] weaponImpactSFX;





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
        GameObject weapon = GameObject.Find("WeaponLogic");
        
        // trigger BloodFX
        var instance = Instantiate(bloodFX[Random.Range(0, bloodFX.Length)], weapon.transform.position, Quaternion.identity);

    }


    //play weapon impact audio
    public void PlayWeaponImpactAudio()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = weaponImpactSFX[Random.Range(0, weaponImpactSFX.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }








}
