using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    [Header("Attack Audio")]
    public AudioClip[] swordSwing;
    public AudioClip[] attackGrunt;

    [HideInInspector] public AudioSource AS_SwordSwing;
    [HideInInspector] public AudioSource AS_AttackGrunt;

    [Header("Clothes Rustling")]
    public AudioClip[] clothesAudio;

    [Header("Running Footsteps")]
    public AudioClip[] mossClips;
    public AudioClip[] grassClips;
    public AudioClip[] herbsClips;
    public AudioClip[] mudClips;

    [Header("Walking Footsteps")]
    public AudioClip[] mossWalk;
    public AudioClip[] grassWalk;
    public AudioClip[] herbsWalk;
    public AudioClip[] mudWalk;

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

    //play clothes audio
    public void PlayClothesAudio()
    {
        AS_Movement.clip = clothesAudio[Random.Range(0, clothesAudio.Length)];
        AS_Movement.PlayOneShot(AS_Movement.clip);
    }
    
    
    // play running footsteps audio
    public void PlayFootsteps()
    {
        AudioClip clip = GetRandomClip();
        AS_Movement.PlayOneShot(clip);
    }

    // play walking footsteps audio
    public void PlayWalkingFootsteps()
    {
        AudioClip clip = GetRandomWalkingClip();
        AS_Movement.PlayOneShot(clip);
    }


    //-----------------------GET RANDOM RUNNING CLIP METHOD----------------------------------------------------
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

    //-----------------------GET RANDOM WALKING CLIP METHOD----------------------------------------------------
    private AudioClip GetRandomWalkingClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0:
                return mossWalk[Random.Range(0, mossWalk.Length)];
            case 1:
                return grassWalk[Random.Range(0, grassWalk.Length)];
            case 2:
                return herbsWalk[Random.Range(0, herbsWalk.Length)];
            case 3:
            default:
                return mudWalk[Random.Range(0, mudWalk.Length)];
        }

    }


}
