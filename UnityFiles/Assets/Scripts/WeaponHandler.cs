using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    [SerializeField] private GameObject weaponLogic;
    [SerializeField] private CharacterEffectsManager characterEffectsManager;
    
    public void EnableWeapon()
    {

        weaponLogic.SetActive(true);
        characterEffectsManager.PlayWeaponTrail();

    }

    public void DisableWeapon()
    {

        weaponLogic.SetActive(false);
        characterEffectsManager.StopWeaponTrail();

    }


}
