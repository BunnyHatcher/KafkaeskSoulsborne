using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    //private GameObject Debugging;

    [Header("Attack Audio")]
    public AudioClip[] swordSwing;
    public AudioClip[] attackGrunt;

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

    public AudioSource audioSource;


    private TerrainDetector terrainDetector;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        terrainDetector = new TerrainDetector();
    }

    //play weapon woosh audio
    public void PlaySwingAudio()
    {
        audioSource.clip = swordSwing[Random.Range(0, swordSwing.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void PlayAttackGrunt()
    {
        audioSource.clip = attackGrunt[Random.Range(0, attackGrunt.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }

    //play clothes audio
    public void PlayClothesAudio()
    {
        audioSource.clip = clothesAudio[Random.Range(0, clothesAudio.Length)];
        audioSource.PlayOneShot(audioSource.clip);
        //Debug.Log(Debugging.name);
    }
    
    
    // play running footsteps audio
    public void PlayFootsteps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    // play walking footsteps audio
    public void PlayWalkingFootsteps()
    {
        AudioClip clip = GetRandomWalkingClip();
        audioSource.PlayOneShot(clip);
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
