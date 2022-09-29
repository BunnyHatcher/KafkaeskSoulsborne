using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    [Header("AudioClips")]
    public AudioClip[] swordSwing;
    public AudioClip[] attackGrunt;

    [HideInInspector]
    public AudioSource AS_SwordSwing;
    public AudioSource AS_AttackGrunt;

    // Start is called before the first frame update
    void Start()
    {
        AS_SwordSwing = gameObject.AddComponent<AudioSource>();
        AS_AttackGrunt = gameObject.AddComponent<AudioSource>();
    }

    //play weapon woosh audio
    public void PlaySwingAudio()
    {
        AS_SwordSwing.clip = swordSwing[Random.Range(0, swordSwing.Length)];
        AS_SwordSwing.Play();
    }

    public void PlayAttackGrunt()
    {
        AS_AttackGrunt.clip = attackGrunt[Random.Range(0, attackGrunt.Length)];
        AS_AttackGrunt.Play();
    }




}
