using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    [Header("AudioClips")]
    public AudioClip[] swordSwing;
    public AudioClip[] attackGrunt;

    [HideInInspector] public AudioSource AS_SwordSwing;
    [HideInInspector] public AudioSource AS_AttackGrunt;

    [Header("Footsteps")]
    public AudioClip[] mossClips;
    public AudioClip[] grassClips;
    public AudioClip[] herbsClips;
    public AudioClip[] mudClips;

    public AudioSource AS_Movement;


    private TerrainDetector terrainDetector;


    // Start is called before the first frame update
    void Start()
    {
        AS_SwordSwing = gameObject.AddComponent<AudioSource>();
        AS_AttackGrunt = gameObject.AddComponent<AudioSource>();

        AS_Movement = GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
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

    // play footsteps audio
    public void PlayFootsteps()
    {
        AudioClip clip = GetRandomClip();
        AS_Movement.PlayOneShot(clip);
    }


    //-----------------------GET RANDOM CLIP METHOD----------------------------------------------------
    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0:
                return mossClips[Random.Range(0, mossClips.Length)];
            case 1:
                return grassClips[Random.Range(0, grassClips.Length)];
            case 2:
                return herbsClips[Random.Range(0, herbsClips.Length)];
            case 3:
            default:
                return mudClips[Random.Range(0, mudClips.Length)];
        }

    }


}
