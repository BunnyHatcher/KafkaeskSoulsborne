using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    //private GameObject Debugging;

    [Header("Attack Audio")]
    [SerializeField]
    private AudioClip[] swordSwing;
    [SerializeField]
    private AudioClip[] attackGrunt;

    [Header("Clothes Rustling")]
    [SerializeField]
    private AudioClip[] clothesAudio;

    [Header("Running Footsteps")]
    [SerializeField]
    private AudioClip[] mossClips;
    [SerializeField]
    private AudioClip[] grassClips;
    [SerializeField]
    private AudioClip[] herbsClips;
    [SerializeField]
    private AudioClip[] mudClips;

    [Header("Walking Footsteps")]
    [SerializeField]
    private AudioClip[] mossWalk;
    [SerializeField]
    private AudioClip[] grassWalk;
    [SerializeField]
    private AudioClip[] herbsWalk;
    [SerializeField]
    private AudioClip[] mudWalk;

    private AudioSource audioSource;


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

    // play Attack Grunt
    public void PlayAttackGrunt()
    {
        audioSource.clip = attackGrunt[Random.Range(0, attackGrunt.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }

    //play clothes audio
    private void PlayClothesAudio()
    {
        
        audioSource.clip = clothesAudio[Random.Range(0, clothesAudio.Length)];
        audioSource.PlayOneShot(audioSource.clip);
        //Debug.Log(Debugging.name);
        
    }
    
    
    // play running footsteps audio
    private void PlayFootsteps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    // play walking footsteps audio
    private void PlayWalkingFootsteps()
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
